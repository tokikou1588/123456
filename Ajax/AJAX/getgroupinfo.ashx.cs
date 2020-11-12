using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AJAX
{
    using System.Data;
    using System.Data.SqlClient;
    using Ajax.BLL;
    using Ajax.Model;

    /// <summary>
    /// getgroupinfo 的摘要说明
    /// </summary>
    public class getgroupinfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.0 去数据库中获取分组数据
            //DataTable db = GetList();
            List<GroupInfo> list = new GroupInfoBLL().GetModelList("");

            //2.0 遍历db中的所有行，将列明作为键，列的值作为值 转换成json格式字符串 
            //[{"GroupId":"1","GroupName":"老板"},{"GroupId":"2","GroupName":"老板1"},{},{}....]
            #region 1.0 通过手工拼接json字符串
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("[");
            //foreach (DataRow item in db.Rows)
            //{
            //    sb.Append("{\"GroupId\":" + item["GroupId"] + ",\"GroupName\":\"" + item["GroupName"] + "\"},");
            //}
            //sb.Remove(sb.Length - 1, 1);
            //sb.Append("]"); 
            #endregion

            #region 2.0 直接json序列化器来将对象序列化成json字符串

            System.Web.Script.Serialization.JavaScriptSerializer jsoner = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonStr = jsoner.Serialize(list);

            #endregion

            // 3.0 将生成好的json字符串响应回异步对象
            //context.Response.Write(sb.ToString());
            context.Response.Write(jsonStr);
        }

        private DataTable GetList()
        {
            DataTable ds = new DataTable();
            using (SqlConnection conn = new SqlConnection("server=.;database=phonebook;uid=sa;pwd=master;"))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from GroupInfo ", conn);
                da.Fill(ds);

            }

            return ds;
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