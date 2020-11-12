using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJAX
{
    /// <summary>
    /// getServerTime 的摘要说明
    /// </summary>
    public class getServerTime : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
         
            context.Response.ContentType = "text/plain";
            if (context.Request.HttpMethod.ToLower() == "get")
            {
                string id = context.Request.QueryString["id"];
                string name = context.Request.QueryString["name"];
                System.Threading.Thread.Sleep(2000);
                context.Response.Write(DateTime.Now.ToString() + " ,id=" + id + "  ,name=" + name);
            }
            else
            {

                string id = context.Request.Form["id"];
                string name = context.Request.Form["name"];

                context.Response.Write(DateTime.Now.ToString() + " ,id=" + id + "  ,name=" + name);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}