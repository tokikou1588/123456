using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site.actions
{
    using Blog.BLL;
    using Blog.Common;
    using Blog.Model;

    /// <summary>
    /// 负责处理相册表的增，删，查，改逻辑
    /// </summary>
    public class albopt : BaseAshx
    {
        BlogPhotoAlblumBLL bll = new BlogPhotoAlblumBLL();
        EnumerationBLL ebll = new EnumerationBLL();
        #region 1.0 所有请求的入口
        public override void SubProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {

                //1.0 约定type为当前请求的类型（增，删，查，改）,此参数是由ajax请求传入
                string type = context.Request.Params["type"];
                switch (type)
                {
                    case "getalllist":
                        getalllist();
                        break;
                    case "getmodelbyid":
                        getmodelbyid();
                        break;
                    case "add":
                        add();
                        break;
                    case "edit":
                        edit();
                        break;
                    case "del":
                        del();
                        break;
                    case "getstatuslist":
                        getStatusList();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //Response.Write();
                //Response.Write(ex.Message); //未将对象引用到实例  {status:error,msg:未将对象引用到实例,datas:null}
                base.WriteError(ex.Message);
            }
        }

        #endregion

        #region 2.0 获取列表逻辑代码

        private void getalllist()
        {
            //1.0 获取相册列表数据集合
            List<BlogPhotoAlblum> list = bll.GetModelList(" PaIsDel = 0 ");

            //2.0 实例化ajaxobj的对象实例            
            obj.status = EStatus.sucess.ToString();
            obj.msg = "获取数据成功";
            obj.datas = list;

            base.Response.Write(Kits.ToJsonString(obj));//{status:ok,msg:获取数据成功,datas:[{},{}]}
        }
        #endregion

        #region 3.0 编辑操作
        private void edit()
        {
            //1.0 接收异步对象通过post操作提交过来的参数
            string id = Request.Form["id"];
            string title = Request.Form["title"];
            string remark = Request.Form["remark"];
            string status = Request.Form["status"];

            //2.0 参数合法性验证
            if (Kits.IsInt(id) == false || Kits.IsInt(status) == false)
            {
                base.WriteError("id和状态必须为整数");
                return;
                //由于End（）会产生一个子线程异常，所以推荐使用return;
                //Response.End();
            }
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(remark))
            {
                base.WriteError("标题和备注不能为空");
                return;
            }

            //3.0 开始将数据更新到db
            BlogPhotoAlblum entity = bll.GetModel(int.Parse(id));
            entity.PaTitle = title;
            entity.PaRemark = remark;
            entity.PaStatu = int.Parse(status);
            bll.Update(entity);

            //4.0 提示用户更新成功
            base.WriteSucess("数据更新成功", null);
        }

        private void getmodelbyid()
        {
            //1.0 获取id参数的值
            string id = Request.QueryString["id"];

            // 2.0 验证参数的合法性
            if (Kits.IsInt(id) == false)
            {
                //{status:error,msg:参数id不合法,datas:null}
                base.WriteError("参数id不合法");
                return;
            }

            // 3.0 根据id去db中获取数据实体
            BlogPhotoAlblum entity = bll.GetModel(int.Parse(id));

            //4.0 调用父类统一的输出方法，将json数据响应回异步对象
            base.WriteSucess("", entity);
        }

        /// <summary>
        /// 负责从表[Enumeration] 中获取e_type=3的数据集合
        /// 以json字符串响应会异步对象
        /// </summary>
        private void getStatusList()
        {
            // 1.0 从数据库查询出数据集合
            List<Enumeration> list = ebll.GetModelList(" e_type = 3 ");
            obj.status = EStatus.sucess.ToString();
            obj.msg = "";
            obj.datas = list;

            // 2.0 将list集合序列化成json字符串以后,响应回异步对象
            base.Response.Write(Kits.ToJsonString(obj));
        }

        #endregion

        #region 4.0 新增
        private void add()
        {
            //1.0 接收异步对象通过post操作提交过来的参数

            string title = Request.Form["title"];
            string remark = Request.Form["remark"];
            string status = Request.Form["status"];

            //2.0 参数合法性验证
            if (Kits.IsInt(status) == false)
            {
                base.WriteError("状态必须为整数");
                return;
                //由于End（）会产生一个子线程异常，所以推荐使用return;
                //Response.End();
            }
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(remark))
            {
                base.WriteError("标题和备注不能为空");
                return;
            }

            // 3.0 新增逻辑
            BlogPhotoAlblum entity = new BlogPhotoAlblum()
            {
                PaAuthor = 2,//UserManager.LogedUserInfo().Id,
                PaAddtime = DateTime.Now,
                PaCoverSrc = "null.jpg",
                PaIsDel = false,
                PaPhotoNum = 0,
                PaPLNum = 0,
                PaRemark = remark,
                PaTitle = title,
                PaStatu = int.Parse(status)
            };
            bll.Add(entity);

            //4.0 提示用户
            base.WriteSucess("数据新增成功");
        }

        #endregion

        #region 5.0 删除操作
        private void del()
        {
            string id = Request.QueryString["id"];
            if (Kits.IsInt(id) == false)
            {
                base.WriteError("id error");
                return;
            }
            BlogPhotoAlblum entity = bll.GetModel(int.Parse(id));
            entity.PaIsDel = true;
            bll.Update(entity);

            base.WriteSucess("删除数据成功");

        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}