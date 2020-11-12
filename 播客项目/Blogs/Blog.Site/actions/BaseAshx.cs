
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site.actions
{
    using Blog.Common;

    public abstract class BaseAshx : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        protected AjaxObj obj = new AjaxObj();

        #region 封装属性，供本身和子类直接使用
        public HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public HttpRequest Request
        {
            get
            {
                return Context.Request;
            }
        }

        public HttpResponse Response
        {
            get
            {
                return Context.Response;
            }
        }
        #endregion

        /// <summary>
        /// 统一的错误输出方法，供所有子类共用
        /// </summary>
        /// <param name="msg"></param>
        public void WriteError(string msg)
        {
            obj.status = EStatus.error.ToString();
            obj.msg = msg;
            Response.Write(Kits.ToJsonString(obj));
        }

        public void WriteSucess(string msg)
        {
            this.WriteSucess(msg, null);
        }

        /// <summary>
        /// 统一的成功输出方法，供所有子类共用
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="object1"></param>
        public void WriteSucess(string msg, object object1)
        {
            obj.status = EStatus.sucess.ToString();
            obj.msg = msg;
            obj.datas = object1;
            Response.Write(Kits.ToJsonString(obj));
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // 如果验证有登录，则应该调用，TODO：以后回来再实现
            SubProcessRequest(context);
        }

        public abstract void SubProcessRequest(HttpContext context);
    }
}