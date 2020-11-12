using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site
{
    using Blog.BLL;
    using Blog.Model;
    using Blog.Common;
    /// <summary>
    /// cateEdit 的摘要说明
    /// </summary>
    public class cateEdit : IHttpHandler
    {
        EnumerationBLL ebll = new EnumerationBLL();
        BlogArticleCateBLL bbll = new BlogArticleCateBLL();

        /// <summary>
        /// 将当前请求的上下文封装成属性Context
        /// </summary>
        public HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string httpmethod = context.Request.HttpMethod.ToLower();
            // 负责将模板页面的占位符替换成参数id对应的数据值
            if (httpmethod == "get")
            {
                ProcessGet();
            }
            else if (httpmethod == "post")   //负责将页面提交过来的最新值更新到数据库中
            {
                ProcessPost();
            }
        }

        private void ProcessPost()
        {
            //1.0 接收浏览器端提交过来的参数
            string id = this.Context.Request.Form["id"];
            string name = this.Context.Request.Form["name"];
            string Remark = this.Context.Request.Form["Remark"];
            string status = this.Context.Request.Form["status"];

            //2.0 对参数进行合法性验证,id和status 一定是整数
            //name和Remark 不允许为空
            if (Kits.IsInt(id) == false || Kits.IsInt(status) == false)
            {
                Context.Response.Write("<script>alert('id或状态参数不合法，请检查'); window.location='/BlogCateList.ashx'</script>");
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(Remark))
            {
                Context.Response.Write("<script>alert('名称或备注参数不合法，请检查'); window.location='/BlogCateList.ashx'</script>");
                return;
            }

            // 3.0 将最新数据更新到数据表
            //3.0.1 根据id得到数据的老实体
            BlogArticleCate entity = bbll.GetModel(int.Parse(id));
            //3.0.2 根据浏览器post给服务器的参数值一一赋值给实体entity的对应属性
            entity.Name = name;
            entity.Remark = Remark;
            entity.Statu = int.Parse(status);

            //3.0.3 将最新的实体entity更新回数据库
            bbll.Update(entity);
            
            //4.0 将提醒响应回浏览器
            Context.Response.Write("<script>alert('恭喜！数据更新成功'); window.location='/BlogCateList.ashx'</script>");
        }

        private void ProcessGet()
        {
            // 根据url传入的参数id获取当前播客分类的数据实体entity
            string id = HttpContext.Current.Request.QueryString["id"];

            //对id进行合法性验证，省略

            BlogArticleCate entity = bbll.GetModel(int.Parse(id));

            //1.0 
            List<Enumeration> list = ebll.GetModelList(" e_type=3 ");
            System.Text.StringBuilder opts = new System.Text.StringBuilder(200);
            if (list.Any())
            {
                foreach (Enumeration item in list)
                {
                    // 开始拼装option标签字符串
                    if (item.e_id == entity.Statu)
                    {
                        opts.Append("<option selected='selected' value='" + item.e_id + "'>" + item.e_cname + "</option>");
                    }
                    else
                    {
                        opts.Append("<option  value='" + item.e_id + "'>" + item.e_cname + "</option>");
                    }
                }
            }

            // 2.0 读取模板editcate.html中的内容
            string phyPath = HttpContext.Current.Server.MapPath("/templates/editCate.html");
            string cText = System.IO.File.ReadAllText(phyPath);

            // 3.0 替换占位符
            cText = cText.Replace("${id}", entity.Id.ToString())
                .Replace("${name}", entity.Name)
                .Replace("${remark}", entity.Remark).Replace("${statuopts}", opts.ToString());

            //4.0 响应浏览器的请求
            HttpContext.Current.Response.Write(cText);
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