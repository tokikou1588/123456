using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    public class Kits
    {
        public static bool IsInt(string str)
        {
            //入参的检验
            if (string.IsNullOrEmpty(str)) return false;

            int res = 0;
            return int.TryParse(str, out res);
        }

        /// <summary>
        /// 将明文的密码转换成md5格式的密文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Entry(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        /// <summary>
        /// 将对象序列化成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString(object obj)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsoner = new System.Web.Script.Serialization.JavaScriptSerializer();
            return jsoner.Serialize(obj);
        }
    }
}
