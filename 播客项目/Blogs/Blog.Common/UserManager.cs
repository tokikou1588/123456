
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    using Blog.Model;
    using System.Web;

    public class UserManager
    {
        /// <summary>
        /// 对当前登录用户的实体做统一的获取操作
        /// </summary>
        /// <returns></returns>
        public static BlogUser LogedUserInfo()
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[Keys.uinfo] as BlogUser;
            }
        }

    }
}
