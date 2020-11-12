<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Blog.Site.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/css.css" rel="stylesheet" />
    <script type="text/javascript">
        window.onload = function () {
            var obj = document.getElementById("imgvcode");
            obj.onclick = function () {
                this.src = "vcode.ashx";
            }
        }
    </script>
</head>
<body>
    <form id="form1" action="login.aspx" method="post">
        <div>
            <table class="list">
                <tr>
                    <th>用户名:</th>
                    <td>
                        <input name="uid" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>密码:</th>
                    <td>
                        <input name="pwd" type="password" />
                    </td>
                </tr>
                <tr>
                    <th>验证码:</th>
                    <td>
                        <input name="vcode" type="text" />
                        <img id="imgvcode" src="vcode.ashx" />
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <input type="submit" value="登录" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
