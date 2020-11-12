using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    using Blog.DBUtility;
    using System.Data;

    /// <summary>
    /// 负责给用户扩展相关逻辑方法使用的，为了防止某天重写使用代码生产工具生成了DAL中的代码
    /// </summary>
    public partial class BlogArticleCateDAL
    {
        /// <summary>
        /// 左链接表BlogUser 和 Enumeration 产生一个新的数据集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetDBJoin(string where)
        {
            string sql = " select b.*,u.LoginName,e.e_cname from BlogArticleCate b ";
            sql += " left join BlogUser u on (b.Author=u.Id) ";
            sql += " left join Enumeration e on (b.Statu=e.e_id and e.e_type=3) ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += "where " + where;
            }

            return DbHelperSQL.Query(sql).Tables[0];
        }

        /// <summary>
        /// 根据id的固定格式：1,2,3来软删除播客分类数据
        /// </summary>
        /// <param name="Idlist"></param>
        /// <returns></returns>
        public bool DeleteList2(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BlogArticleCate set isdel=1 ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
