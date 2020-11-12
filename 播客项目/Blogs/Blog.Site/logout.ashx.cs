using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site
{
    /// <summary>
    /// logout 的摘要说明
    /// </summary>
    public class logout : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["uinfo"] != null)
            {
                context.Session["uinfo"] = null;
               
            }
            context.Response.Redirect("/login.aspx");
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