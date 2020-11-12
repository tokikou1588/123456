using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site
{
    using Blog.BLL;

    /// <summary>
    /// DeleteCate 的摘要说明
    /// </summary>
    public class DeleteCate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            try
            {
                //1.0 接收浏览器提交给服务器的参数
                string ids = context.Request.Form["chk"];

                //2.0  判断ids 的合法性
                if (string.IsNullOrEmpty(ids))
                {
                    context.Response.Write("<script>alert('删除条件参数非法，请重写填写');window.location='/BlogCateList.ashx'</script>");
                    return;
                }
                //3.0  根据ids进行删除操作
                BlogArticleCateBLL bll = new BlogArticleCateBLL();
                bll.DeleteList2(ids);

                //4.0  将提示信息返回给用户
                context.Response.Write("<script>alert('批量删除成功');window.location='/BlogCateList.ashx'</script>");
            }
            catch (Exception ex)
            {
                //将异常信息编写到文本日志或者数据库中
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