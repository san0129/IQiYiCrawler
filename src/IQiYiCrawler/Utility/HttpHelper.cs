using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IQiYiCrawler.Utility
{
    public class HttpHelper
    {
        private static Logger logger = new Logger(typeof(HttpHelper));
        /// <summary>
        /// 根据html下载内容  之前是GB2312
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Download(string url)
        {
            return DownloadHtml(url, System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// UTF8
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        //public static string Download(string url)
        //{
        //    return DownloadHtml(url, System.Text.Encoding.UTF8);
        //}
        /// <summary>
        /// 下载html
        /// http://tool.sufeinet.com/HttpHelper.aspx
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url, System.Text.Encoding encode)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;//模拟请求
                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";// 
                //request.Host = "search.yhd.com";

                //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        logger.Warn(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), encode);
                            html = sr.ReadToEnd();//读取数据
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format("DownloadHtml抓取{0}保存失败", url), ex);
                            html = null;
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    logger.Error("远程服务器返回错误: (306)。", ex);
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }
    }
}
