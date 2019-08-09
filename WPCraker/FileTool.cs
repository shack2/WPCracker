using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WPCraker.Tools
{
    class FileTool
    {
        //读取单个字典文件（文件编码为UTF-8）
        public static List<String> readFileToList(String path)
        {

            List<String> list = new List<String>();
            FileStream fs_dir = null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);

                reader = new StreamReader(fs_dir);

                String lineStr;

                while ((lineStr = reader.ReadLine()) != null)
                {
                    if (!lineStr.Equals(""))
                    {
                        list.Add(lineStr);
                    }
                }
            }
            catch (Exception e)
            {
                Tool.SysLog("FileTools-readFileToList-error:读取文件到添加到集合发生错误！");
            }
            finally {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return list;
        }

        public static List<String> readFileDomainsToList(String path)
        {

            List<String> list = new List<String>();
            FileStream fs_dir = null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);

                reader = new StreamReader(fs_dir);

                String lineStr;

                while ((lineStr = reader.ReadLine()) != null)
                {
                    if (!lineStr.Equals(""))
                    {
                        String domain=lineStr;
                        if (!"".Equals(domain))
                        {
                            list.Add(domain);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Tool.SysLog("readFileDomainsToList error:读取域名文件到添加到集合发生错误！"+e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return list;
        }

        //读取文件
        public static String readFileToString(String path)
        {
            String str = "";
            FileStream fs_dir=null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fs_dir);
                str = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                Tool.SysLog("FileTools-readFileToString-error:读取文件内容发生错误！");
            }finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return str;
            
        }
        //读取文件
        public static Byte[] readFileToByte(String path)
        {
            Byte[] buffer = null;
            FileStream fs_dir=null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs_dir);
                int len = (int)fs_dir.Length;

                buffer = new byte[len];

                int size = br.Read(buffer, 0, len);

                reader.Read();
                
            }
            catch (Exception e)
            {
                Tool.SysLog("FileTools-readFileToByte-error:读取文件内容发生错误！");
            }finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return buffer;
            
        }
        public static object c = "";
       
        public static void AppendLogToFile(String path, String log)
        {
            //锁住，防止多线程引发错误
            lock (c)
            {
                FileStream fs_dir = null;
                StreamWriter sw = null;
                try
                {
                    fs_dir = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/" + path, FileMode.Append, FileAccess.Write);

                    sw = new StreamWriter(fs_dir);

                    sw.WriteLine(log);

                    sw.Close();

                    fs_dir.Close();

                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                    if (fs_dir != null)
                    {
                        fs_dir.Close();
                    }
                }
            }

        }
    }
}
