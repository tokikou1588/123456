using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site
{
    using Blog.BLL;
    using Blog.Model;
    using System.Data;

    /// <summary>
    /// BlogCateList 的摘要说明
    /// </summary>
    public class BlogCateList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //1.0 去数据库读取分类的所有数据
            BlogArticleCateBLL bll = new BlogArticleCateBLL();
            DataTable tb = bll.GetDBJoin(" b.isdel=0 ");

            //2.0 根据第一步的数据生成<tr>标签
            System.Text.StringBuilder trs = new System.Text.StringBuilder(200);
            //if (list.Any())  //Any():判断list集合中如果有至少一条数据则返回true，否则返回false
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow entity in tb.Rows)
                {
                    trs.Append("<tr>");
                    trs.Append("<td><input type='checkbox' name='chk' value='" + entity["Id"] + "'></td>");
                    trs.Append("<td>" + entity["Id"] + "</td>");
                    trs.Append("<td>" + entity["LoginName"] + "</td>");
                    trs.Append("<td>" + entity["Name"] + "</td>");
                    trs.Append("<td>" + entity["e_cname"] + "</td>");
                    trs.Append("<td>" + entity["Addtime"] + "</td>");
                    trs.Append("<td><a href='cateEdit.ashx?id=" + entity["Id"] + "'>编辑</a> | <a href='javascript:void(0)' onclick='del(" + entity["Id"] + ")'>删除</a></td>");
                    trs.AppendLine("</tr>");                    
                }
            }
            //3.0 替换模板中的占位符${trs}
            //3.0.1 读取模板catelist.html 中的内容
            string phyPath = context.Server.MapPath("/templates/catelist.html");
            string cText = System.IO.File.ReadAllText(phyPath);
            cText = cText.Replace("${trs}", trs.ToString());

            //4.0 将替换后的字符串响应给浏览器
            context.Response.Write(cText);
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
