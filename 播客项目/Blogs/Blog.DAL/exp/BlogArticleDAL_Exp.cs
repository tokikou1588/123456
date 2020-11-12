using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    using Blog.DBUtility;
    using System.Data;

    public partial class BlogArticleDAL
    {
        public DataTable GetListJoin(string where)
        {
            string sql = " select *,c.Name,e.e_cname from BlogArticle b ";
            sql += " left join BlogArticleCate c on (b.ACate=c.Id) ";
            sql += " left join Enumeration e on (b.AStatu=e.e_id) ";

            if (string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }

            return DbHelperSQL.Query(sql).Tables[0];
        }
    }
}
