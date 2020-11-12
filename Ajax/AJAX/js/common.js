var ajaxHelper = {
    markXHR: function () {
        var xhr;
        //高版本浏览器才支持 new XMLHttpRequest() 操作
        if (window.XMLHttpRequest) {
            xhr = new XMLHttpRequest();
        } else //适配低版本浏览器的异步对象创建工作
        {
            xhr = new ActiveXObject("Microsoft.XMLHTTP");
        }
        return xhr;
    },
    ajaxGet: function (url, callBackFun) {
        this.ajaxProcess("get", url, null, callBackFun);
    },
    ajaxPost: function (url, parms, callBackFun) {
        this.ajaxProcess("post", url, parms, callBackFun);
    },
    //通用的ajax请求包装方法，可以被ajaxGet和ajaxPost方法来调用
    //1、method：表示请求方法  2 url ：表示请求的服务器路径  3 parms:只有post才有参数，如果是get请求则为null
    //4 callBackFun:回调函数，其逻辑代码是在调用方法中实现好以后，传入ajaxProcess 方法中的
    ajaxProcess: function (method, url, parms, callBackFun) {
        // 将字符串统一转换成小写
        var httpMethod = method.toLowerCase();
        //1.0 实例化异步对象
        var xhr = this.markXHR();
        //2.0 设置请求相关参数
        xhr.open(httpMethod, url, true);

        //3.0 设置请求报文头
        if (httpMethod == "get") {
            xhr.setRequestHeader("If-Modified-Since", "0");
        } else {
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        }

        //4.0 设置回调函数
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                // 获取服务器响应回来的响应报文体的数据
                var result = xhr.responseText;
                //由于result 是一个json格式的字符串，所以在此处统一转换成js对象（数组），再传入回调函数
                var jsobj = JSON.parse(result);
                // 调用回调函数，将js对象传入
                callBackFun(jsobj);
            }
        }

        //5.0 发送请求给服务器
        if (httpMethod == "get") {
            xhr.send(null);
        } else {
            xhr.send(parms);
        }

    }

}