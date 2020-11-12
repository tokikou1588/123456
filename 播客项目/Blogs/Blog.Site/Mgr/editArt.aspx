<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="editArt.aspx.cs" Inherits="Blog.Site.Mgr.editArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form action="editArt.aspx" method="post">
        <input type="hidden" name="id" value="<%=Aid %>" />
        <table class="list">
            <tr>
                <th>所属类别</th>
                <td>
                    <select name="ACate">
                        <%= cateopts %>
                    </select></td>
            </tr>
            <tr>
                <th>标题</th>
                <td>
                    <input type="text" name="ATitle" value="<%=ATitle %>" />
                </td>
            </tr>
            <tr>
                <th>文章内容</th>
                <td>
                    <textarea cols="50" rows="10" name="AContent"><%=AContent %></textarea>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <input type="submit" value="编辑" />
                    <input type="button" value="返回列表" onclick="window.location = 'BlogArticleList.aspx'" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
