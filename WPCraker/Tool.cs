using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace WPCraker.Tools
{
    class Tool
    {
        public static void SysLog(String log)
        {
            FileTool.AppendLogToFile("logs/"+DateTime.Now.ToLongDateString()+".log.txt",log+"----"+DateTime.Now);
        }
        public static String getDomainByString(String weburl)
        {
            try
            {
                if (!weburl.StartsWith("http"))
                {
                    weburl = "http://" + weburl;
                }
                Uri u = new Uri(weburl);
                
                if (u.Port==80)
                {
                    return u.Scheme + "://" + u.Host + "/"+u.LocalPath;
                }
                return u.Scheme + "://" + u.Host + ":" + u.Port + "/" + u.LocalPath;

            }
            catch (Exception e) 
            {
            }
            return "";
        }
        public static String updateTheDomain(String weburl)
        {
            if ("".Equals(weburl.Trim()))
            {
                return "";
            }
            if (!weburl.StartsWith("http"))
            {
                weburl = "http://" + weburl;
            }
            
            return weburl;
        }
        static String[] regx = { @"\/author\/(?<username>[\w -]{3,50})\/", @" (?<username>[\w -]{3,50})发布的所有日志", @"由(?<username>[\w -]{3,50})发表的", @"Posts by (?<username>[\w -]{3,50}) Feed" };
        public static String getUserName(HttpResult hr)
        {
            String username = "";
            Match user_m = Regex.Match(hr.location, @"author\/(?<username>[\w -]{3,50})");
            if (user_m.Success)
            {
                username = user_m.Groups["username"].Value.Replace("/","").Trim();
                return username;
            }
            else {
                foreach (String reg in regx)
                {
                    if ("".Equals(username))
                    {
                        user_m = Regex.Match(hr.html, reg);
                        if (user_m.Success)
                        {
                            username = user_m.Groups["username"].Value.Replace("/", "").Trim();
                        }
                    }
                    if (!String.IsNullOrEmpty(username))
                    {
                        return username;
                    }
                }
            }
            return username;

        }

        public static List<String> getUserNameByFeed(String html)
        {
            List<String> userList = new List<String>();
            MatchCollection user_m = Regex.Matches(html, @"creator\>\<\!\[CDATA\[(?<username>[\w -]{3,50})\]\]\>\<\/dc");
            foreach (Match m in user_m) {
                if (m.Success)
                {
                    String username = m.Groups["username"].Value;
                    if (!userList.Contains(username))
                    {
                        userList.Add(username);
                    }
                } 
            }
            return userList;
        }

        public static String getSystemSid()
        {

            String sid = "";
            try
            {
                //获得系统名称
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
                sid = rk.GetValue("ProductName").ToString();
                rk.Close();
                //获得系统唯一号，系统安装id和mac组合
                sid += "_";
                
                var officeSoftware = new ManagementObjectSearcher("SELECT ID, ApplicationId, PartialProductKey, LicenseIsAddon, Description, Name, OfflineInstallationId FROM SoftwareLicensingProduct where PartialProductKey <> null");
                var result = officeSoftware.Get();
                foreach (var item in result)
                {
                    String c = item.GetPropertyValue("name").ToString();

                    if (item.GetPropertyValue("name").ToString().StartsWith("Windows"))
                    {

                        sid += item.GetPropertyValue("OfflineInstallationId").ToString() + "_";
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                sid += "ex_";
            }
            String mac = "";
            try
            {
                NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in fNetworkInterfaces)
                {
                    String fCardType = "o";
                    String fRegistryKey = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + adapter.Id + "\\Connection";
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                    if (rk != null)
                    {
                        String fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                        int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                        if (!String.IsNullOrEmpty(fPnpInstanceID) && fPnpInstanceID.StartsWith("PCI"))
                        {
                            if (fMediaSubType == 2)
                            {
                                fCardType = "w";
                            }
                            else
                            {
                                fCardType = "n";
                            }
                            mac = fCardType + ":" + adapter.GetPhysicalAddress().ToString() + "--";
                        }
                    }
                }
                if (mac.EndsWith("--"))
                {
                    mac = mac.Substring(0, mac.Length - 2);
                }
            }
            catch
            {
            }
            return sid + mac;

        }
    }
}
