using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class ImageController : Controller
    {
        //[HttpGet]
        //public byte[] Get(string url = "http://pic8.qiyipic.com/image/20180314/22/4b/v_112874974_m_601_m3_180_236.jpg")
        //{
        //    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;//模拟请求
        //    request.Referer = "http://list.iqiyi.com/";
        //    var response = request.GetResponse();
        //    var stream = response.GetResponseStream();
        //    byte[] buffer = new byte[stream.Length];
        //    stream.Write(buffer, 0, buffer.Length);

        //    return buffer;
        //}
    }
}