<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="AlbList_Demo.aspx.cs" Inherits="Blog.Site.Alb.AlbList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/common.js"></script>
    <style type="text/css">
        #abtitle {
            height:30px;
            background-color:#0094ff;
            color:white;
            font-size:18px;
            line-height:30px;
            padding-left:15px;          
        }

        #ablist {
            border:dashed 1px #000;
            min-height:500px;
            overflow:auto;
            height:500px;
        }
            #ablist .abldiv {
                height:170px;
                width:165px;
                display:inline-block;
                margin-left:3px;
                border:solid 1px #000;
            }
                #ablist .abldiv li {
                    text-align:center;
                    margin-top:5px;
                    padding:3px;
                }
        .abldiv img {
            cursor:pointer;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abtitle">
        相册管理
    </div>
    <div id="ablist">
        <div class="abldiv">
            <ul>
                <li><img src="../images/null.jpg" height="100px" width="120px" /></li>
                <li>美女</li>
                <li><a>编辑</a> | <a>删除</a></li>
            </ul>
        </div>
        <div class="abldiv">
              <ul>
                <li><img src="../images/null.jpg" height="100px" width="120px" /></li>
                <li>美女</li>
                <li><a>编辑</a> | <a>删除</a></li>
            </ul>
        </div>
        <div class="abldiv">
              <ul>
                <li><img src="../images/null.jpg" height="100px" width="120px" /></li>
                <li>美女</li>
                <li><a>编辑</a> | <a>删除</a></li>
            </ul>
        </div>
        <div class="abldiv">
              <ul>
                <li><img src="../images/null.jpg" height="100px" width="120px" /></li>
                <li>美女</li>
                <li><a>编辑</a> | <a>删除</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
