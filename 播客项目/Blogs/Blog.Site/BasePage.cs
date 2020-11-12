using Blog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site
{
    public class BasePage : System.Web.UI.Page
    {
        /*
         * 注意：由于当前BasePage 构造函数实在管道第8个事件被调用，但是session的赋值操作是在第9,10个事件，多次
         * 此处调用会报错
         */
        //public BasePage()
        //{
        //    if (Session["uinfo"] == null)
        //    {
        //        Response.Redirect("/login.aspx");
        //    }
        //}

        protected override void OnPreInit(EventArgs e)
        {
            //实现登录验证的代码
            if (Session[Keys.uinfo] == null)
            {
                Response.Redirect("/login.aspx");
            }

            base.OnPreInit(e);
        }
    }
}