using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using WPCraker.Tools;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;

namespace WPCreaker.Tools
{
    
    class HttpTool
    {
        public static int getCode(String url,int timeout)
        {

            HttpWebResponse response = null;
            StreamReader sr = null;
            HttpWebRequest request = null;
            try
            {

                //设置模拟http访问参数
                Uri uri = new Uri(url);
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192 | SecurityProtocolType.Ssl3;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                }
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/5.0";
                request.Method = "HEAD";
                request.Timeout = timeout*1000;
              
                request.AllowAutoRedirect = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 10000;
                request.AllowWriteStreamBuffering = false;
                response = (HttpWebResponse)request.GetResponse();

                return (int)response.StatusCode;
            }
            catch (Exception e)
            {
                Tool.SysLog("发送http请求发生异常！" + e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return 0;
        }
        public static String getHtml(String url,int timeout)
        {
            
            HttpWebResponse response = null;
            StreamReader sr = null;
            HttpWebRequest request = null;
            try
            {

                //设置模拟http访问参数
                Uri uri = new Uri(url);
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192 | SecurityProtocolType.Ssl3;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                }
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0";
                request.Timeout = timeout*1000;
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.AllowAutoRedirect = true;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 10000;
                request.AllowWriteStreamBuffering = false;
                response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                //读取服务器端返回的消息 
                String html = unZipAndDeflate(response);
                return html;
            }
            catch (Exception e)
            {
                Tool.SysLog("发送http请求发生异常！" + e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return "";
        }

        public static HttpResult getHttpResult(String url,int timeout,bool AutoRedirect)
        {
            HttpResult hr = new HttpResult();
            HttpWebResponse response = null;
            StreamReader sr = null;
            HttpWebRequest request = null;
           
            try
            {

                //设置模拟http访问参数
                Uri uri = new Uri(url);
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192 | SecurityProtocolType.Ssl3;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                }
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0";
                request.Timeout = timeout*1000;
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.AllowAutoRedirect = AutoRedirect;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 10000;
                request.AllowWriteStreamBuffering = false;
                response = (HttpWebResponse)request.GetResponse();
                hr.location= response.GetResponseHeader("Location");
                hr.html=unZipAndDeflate(response);
                hr.responseCode = (int)response.StatusCode;
                return hr;
            }
            catch (Exception e)
            {
                Tool.SysLog("发送http请求发生异常！" + e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return hr;
        }

        public static String unZipAndDeflate(HttpWebResponse response) {

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {

                        return reader.ReadToEnd();
                    }
                }
            }
            else if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {

                        return reader.ReadToEnd();
                    }

                }
            }
            else
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {

                       return reader.ReadToEnd();
                    }
                }
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        public static String getLocationByPost(String url,String data,int timeout)
        {

            HttpWebResponse response = null;
            StreamReader sr = null;
            HttpWebRequest request = null;
            try
            {

                //设置模拟http访问参数
                Uri uri = new Uri(url);
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072| (SecurityProtocolType)768|(SecurityProtocolType)192|SecurityProtocolType.Ssl3;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                   
                }
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = timeout*1000;
                request.AllowAutoRedirect = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 10000;
                request.AllowWriteStreamBuffering = false;
                request.Headers.Add("Cookie", "wp-settings-time-1=1390368100; wordpress_test_cookie=WP+Cookie+check; bdshare_firstime=1388392036818");
                
                byte[] bydata = Encoding.ASCII.GetBytes(data);
                request.ContentLength = bydata.Length;
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(bydata, 0, bydata.Length);
                reqStream.Close();

                response = (HttpWebResponse)request.GetResponse();
                StreamReader str = new StreamReader(response.GetResponseStream());
                String loca = response.GetResponseHeader("Location");
                return loca;
            }
            catch (Exception e)
            {
                Tool.SysLog("发送http请求发生异常！" + e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return "";
        }

        //获取HTTP状态码
        public static int getHttpCode(String method, String url, int timeout)
        {
            int code = 0;
            try
            {
                String result = "";
                //查找状态码
                if (result != null && !"".Equals(result))
                {
                    code = int.Parse(result.Split(' ')[1]);
                }
            }
            catch (Exception e)
            {

            }
            return code;
        }
    }
}
