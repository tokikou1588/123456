using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.Site.Mgr
{
    using System.Text;
    using Blog.BLL;
    using Blog.Model;
    using Blog.Common;

    public partial class editArt : BasePage
    {
        #region 1.0 定义变量
        public StringBuilder cateopts = new StringBuilder(200); //负责存放播客类别表中的数据对应的option标签
        public string ATitle = string.Empty;   //负责存放标题值
        public string AContent = string.Empty;//负责存放内容值
        public string Aid = string.Empty;

        BlogArticleBLL bll = new BlogArticleBLL();
        BlogArticleCateBLL cbll = new BlogArticleCateBLL();
        #endregion

        #region 2.0 处理逻辑的入口方法
        /// <summary>
        /// 由于页面生命周期中的Load事件要先于Render事件执行，所以可以在Page_Load方法中对
        /// cateopts，ATitle，AContent 进行复制后，最终在aspx页面就可以获取到三个变量对应的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //get请求做的事情为：根据参数id值获取老数据呈现给用户
            //post请求做的事情为：根据浏览器提交的参数值修改数据库中对应的数据
            string httpMethod = Request.HttpMethod.ToLower();
            if (httpMethod == "get")
            {
                ProcessGet();
            }
            else if (httpMethod == "post")
            {
                ProcessPost();
            }

        }
        #endregion

        #region 3.0 处理get请求的逻辑方法
        /// <summary>        
        /// get请求做的事情为：根据参数id值获取老数据呈现给用户
        /// </summary>
        private void ProcessGet()
        {
            //1.0 获取url传入的id参数值
            string Aid = base.Request.QueryString["id"];

            //2.0 验证参数合法性
            if (Kits.IsInt(Aid) == false)
            {
                Response.Write("<script>alert('参数id非法');window.location='BlogArticleList.aspx'</script>");
                return;
            }

            //3.0 根据id查询数据库
            BlogArticle entity = bll.GetModel(int.Parse(Aid));
            if (entity == null)
            {
                Response.Write("<script>alert('参数id没有对应的数据，请检查');window.location='BlogArticleList.aspx'</script>");
                return;
            }

            //成员变量赋值操作
            this.ATitle = entity.ATitle;
            this.AContent = entity.AContent;
            this.Aid = entity.AId.ToString();

            //4.0 去数据表BlogArticleCate 查询出所有有效的数据
            List<BlogArticleCate> list = cbll.GetModelList(" IsDel = 0 ");
            if (list.Any())
            {
                foreach (BlogArticleCate item in list)
                {
                    if (item.Id == entity.ACate)
                    {
                        cateopts.Append("<option selected='selected' value='" + item.Id + "'>" + item.Name + "</option>");
                    }
                    else
                    {
                        cateopts.Append("<option value='" + item.Id + "'>" + item.Name + "</option>");
                    }
                }
            }
        }
        #endregion

        #region 4.0 处理Post请求的逻辑方法
        /// <summary>
        /// post请求做的事情为：根据浏览器提交的参数值修改数据库中对应的数据
        /// </summary>
        private void ProcessPost()
        {
            //1.0 接收浏览器post给服务器的参数值
            string aid = Request.Form["id"];
            string ACate = Request.Form["ACate"];
            string ATitle = Request.Form["ATitle"];
            string AContent = Request.Form["AContent"];

            //.2.0 参数合法性验证

            //3.0 开始编辑功能逻辑
            BlogArticle entity = bll.GetModel(int.Parse(aid));
            entity.ACate = int.Parse(ACate);
            entity.ATitle = ATitle;
            entity.AContent = AContent;
            bll.Update(entity);

            //4.0 提醒用户编辑成功
            Response.Write("<script>alert('恭喜，数据编辑成功');window.location='BlogArticleList.aspx'</script>");

        }
        #endregion
    }
}