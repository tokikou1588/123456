using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL
{
    using System.Data;

    public partial class BlogArticleCateBLL
    {
        /// <summary>
        /// 左链接表BlogUser 和 Enumeration 产生一个新的数据集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetDBJoin(string where)
        {
            return dal.GetDBJoin(where);
        }

        /// <summary>
        /// 根据id的固定格式：1,2,3来软删除播客分类数据
        /// </summary>
        /// <param name="Idlist"></param>
        /// <returns></returns>
        public bool DeleteList2(string Idlist)
        {
            return dal.DeleteList2(Idlist);
        }
    }
}
