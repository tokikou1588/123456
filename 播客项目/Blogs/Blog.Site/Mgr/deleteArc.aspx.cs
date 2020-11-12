using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.Site.Mgr
{
    using Blog.BLL;
    using Blog.Model;

    public partial class deleteArc : BasePage
    {
        BlogArticleBLL bll = new BlogArticleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //做删除逻辑操作

            //1.0 得到浏览器传入的ID参数值
            string id = Request.QueryString["id"];

            //2.0 合法性验证

            //3.0 开始逻辑删除操作
            //3.0.1 根据id先获取老的数据实体
            BlogArticle entity = bll.GetModel(int.Parse(id));
            //3.0.2 将entity实体中的isdel 设置为 1
            entity.AIsDel = true;
            //3.0.3 调用bll中的update方法将更新后的实体entity保存回数据库
            bll.Update(entity);

            //4.0 提示删除成功
            Response.Write("<script>alert('数据删除成功');window.location='BlogArticleList.aspx'</script>");

        }
    }
}