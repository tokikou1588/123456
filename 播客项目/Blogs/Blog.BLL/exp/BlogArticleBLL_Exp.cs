using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL
{
    public partial class BlogArticleBLL
    {
        public DataTable GetListJoin(string where)
        {
            return dal.GetListJoin(where);
        }
    }
}
