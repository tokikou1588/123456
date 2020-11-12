<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Blog.Site.Alb.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/alb.css" rel="stylesheet" />
    <script src="/js/common.js"></script>
    <script src="/js/jquery-1.9.1.js"></script>
    <script src="/js/jquery.tmpl.min.js"></script>
    <script src="/js/msgBox.js"></script>
    <script type="text/javascript">

        var isEdit = false;
        var msgbox;


        $(function () {

            //实例化msgbox控件（漂亮提示框）的实例
            msgbox = new MsgBox({ imghref: "/img/" });

            //调用获取列表方法
            getlist();

            //负责从表Enumeration 获取状态数据
            getStatusList();
        });

        //1.0 负责从表Enumeration 获取状态数据
        function getStatusList() {
            ajaxHelper.ajaxGet("/actions/albopt.ashx?type=getstatuslist", function (jsobj) {
                //将数据填充到select 标签中
                var arr = jsobj.datas;
                var selobj = document.getElementById("status");
                for (var i = 0; i < arr.length; i++) {
                    var item = arr[i];
                    var opt = new Option(item.e_cname, item.e_id);
                    selobj.options.add(opt);
                }
            });
        }

        //2.0 负责获取相册的列表
        function getlist() {
            // 利用ajax请求后台一般处理程序，得到相册的json格式数据，开始利用模板生成页面
            ajaxHelper.ajaxGet("/actions/albopt.ashx?type=getalllist", function (jsobj) {
                //此时jsobj一定是一个js的对象，其中jsobj.datas 才是正常要取得的逻辑数据，它有可能是一个js对象或者数组
                if (jsobj.status == "error") {
                    alert(jsobj.msg);
                } else if (jsobj.status == "sucess") {
                    //正常处理逻辑。利用jquery.tmpl.min.js中的tmpl方法 将jsobj.datas中的数据一一替换到id为ablTmpl的模板中的${}等占位符
                    //最终返回生成好的html代码追加到id=ablist的div中
                    $("#ablist").html($("#ablTmpl").tmpl(jsobj.datas));
                }
            });
        }

        //2.0.1 负责根据图片名称返回图片的完整虚拟路径，如果图片为null.jpg则直接显示默认图片，此方法会被模板
        //jquery.tmpl.min 来调用
        function getimgpath(imgname) {
            if (imgname == "null.jpg") {
                return "/images/null.jpg"
            } else {
                return "/upload/thum/" + imgname;
            }
        }

        //3.0 负责将老数据加载到面板中，并且弹出编辑面板
        function editload(paid) {
            isEdit = true;
            // 1.0 ajax 请求paid对应的数据
            ajaxHelper.ajaxGet("/actions/albopt.ashx?type=getmodelbyid&id=" + paid, function (jsobj) {
                var entity = jsobj.datas;
                $("#id").val(entity.PaId);
                $("#title").val(entity.PaTitle);
                $("#remark").val(entity.PaRemark);
                $("#status > option[value='" + entity.PaStatu + "']").attr("selected", "selected");
            });
            //2.0 打开面板
            openPanel(true);
        }

        //3.0.1 负责打开（isopen=true）或者关闭(isopen=false)新增编辑面板  
        function openPanel(isopen) {
            if (isopen) {
                $("#edit").show(); //打开面板
            } else {
                $("#edit").hide();//关闭面板
            }
        }

        //4.0 负责提交数据到服务器页面，进行新增或者编辑操作
        function submitData() {
            if (isEdit) {
                //做编辑逻辑
                edit();
            }
            else {
                //新增逻辑
                add();
            }
        }

        //4.0.1 编辑操作
        function edit() {
            //1.0 获取当前编辑面板中所有的值
            //遍历id=f1的form表单中带有name属性的元素，将其序列化成参数格式的字符串。例如：//title=a&remark=b&status=4
            var pamrs = $("#f1").serialize();
            pamrs += "&type=edit";

            //2.0 利用ajax的post请求将参数提交给服务器页面
            ajaxHelper.ajaxPost("/actions/albopt.ashx", pamrs, function (jsobj) {
                msgbox.showMsgOk(jsobj.msg, function () {
                    //刷新自己
                    window.location = window.location;
                    //window.location.reload();
                });
            });
        }

        //负责将isedit赋值为false，并且打开面板，同时将文本框中的内容清空
        function addOpt() {
            isEdit = false;
            $("#id").val("");
            $("#title").val("");
            $("#remark").val("");
            $("#status > option").removeAttr("selected");

            openPanel(true);
        }

        //4.0.2 新增功能
        function add() {
            var pamrs = $("#f1").serialize();
            pamrs += "&type=add";

            ajaxHelper.ajaxPost("/actions/albopt.ashx", pamrs, function (jsobj) {
                msgbox.showMsgOk(jsobj.msg, function () {
                    window.location = window.location;
                });
            });
        }

        //负责删除相册
        function del(paid,t) {
            if (confirm("你是否删除数据")) {
                ajaxHelper.ajaxGet("/actions/albopt.ashx?type=del&id=" + paid, function (jsobj) {
                    msgbox.showMsgOk(jsobj.msg, function () {
                        //找到当前删除按钮所在的div，将其remove掉
                        //$(t).parent().parent().parent().remove();

                        getlist();
                    });
                });
            }
        }


    </script>
    <script id="ablTmpl" type="text/x-jquery-tmpl">
        <div class="abldiv">
            <ul>
                <li>
                    <img src="${getimgpath(PaCoverSrc)}" height="100px" width="120px" /></li>
                <li>${PaTitle}</li>
                <li><a href="javascript:void(0);" onclick="editload(${PaId})">编辑</a>
                    | <a href="javascript:void(0);" onclick="del(${PaId},this)">删除</a></li>
            </ul>
        </div>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abtitle">
        相册管理
        <input type="button" value="新增相册" onclick="addOpt()" />
    </div>
    <div id="ablist">
    </div>
    <%--新增和编辑的面板--%>
    <div id="edit">
        <form id="f1">
            <input type="hidden" id="id" name="id" />
            <table class="list">
                <tr>
                    <th>相册名称</th>
                    <td>
                        <input id="title" name="title" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>备注</th>
                    <td>
                        <textarea id="remark" name="remark"></textarea>
                    </td>
                </tr>
                <tr>
                    <th>状态</th>
                    <td>
                        <select id="status" name="status"></select>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <input type="button" value="提交" onclick="submitData()" />
                        <input type="button" value="关闭" onclick="openPanel(false)" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>
