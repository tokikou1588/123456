using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    /// <summary>
    /// 负责将后台数据返回成统一的json字符串格式，最终此实例会被tojsonstring()方法序列化
    /// </summary>
    public class AjaxObj
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 提示语
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 真正的逻辑数据
        /// </summary>
        public object datas { get; set; }
    }

    public enum EStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        sucess,
        /// <summary>
        /// 异常
        /// </summary>
        error
    }
}
