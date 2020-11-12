using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.Site
{
    using Blog.BLL;
    using Blog.Common;
    using Blog.Model;

    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower() == "post")
            {
                //1.0 接收浏览器post给服务器的参数
                string vcode = Request.Form["vcode"];
                string pwd = Request.Form["pwd"];
                string uid = Request.Form["uid"];

                // 2.0 验证参数的合法性
                string vcodeFromSession = Session[Keys.vcode].ToString();
                if (string.IsNullOrEmpty(vcode) || !vcodeFromSession.Equals(vcode, StringComparison.OrdinalIgnoreCase))
                {
                    Response.Write("<script>alert('验证码错误');window.location='/login.aspx'</script>");
                    return;
                }

                // 3.0 验证用户名和密码的合法性
                //3.0.1 将明文的密码转换成md5格式的密文
                string md5pwd = Kits.MD5Entry(pwd);
                //3.0.2 根据用户名和密码去数据库中查询
                BlogUserBLL bll = new BlogUserBLL();
                List<BlogUser> list = bll.GetModelList(" LoginName = '" + uid + "' and LoginPwd = '" + md5pwd + "'");
                if (list.Any())
                {
                    //将用户信息实体存入session中，来标示登录成功了
                    Session[Keys.uinfo] = list[0];
                    Response.Redirect("/Mgr/BlogArticleList.aspx");
                }
            }
        }
    }
}