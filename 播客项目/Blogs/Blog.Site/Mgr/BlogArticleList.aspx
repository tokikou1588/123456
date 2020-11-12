<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="BlogArticleList.aspx.cs" Inherits="Blog.Site.Mgr.BlogArticleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--专门用来存放此页面专用的css和js等代码--%>
    <script type="text/javascript">
        function del(id) {
            if (confirm('是否删除此数据')) {
                window.location = 'deleteArc.aspx?id=' + id;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form action="/DeleteBlogArticle.ashx" method="post">
        <table class="list">
            <tr>
                <td colspan="7">
                    <input type="submit" value="批量删除" /></td>
            </tr>
            <tr>
                <th>
                    <input id="chkAll" type="checkbox" value="全选" /></th>
                <th>文章表ID</th>
                <th>所属类别</th>
                <th>标题</th>
                <th>状态</th>
                <th>添加日期</th>
                <th></th>
            </tr>
            <%= trs %>
        </table>
    </form>
</asp:Content>
