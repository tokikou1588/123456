var num = 1;
var NWS001 = {
    search: function () {
        num = 2;
        //获取table对象
        var table = document.getElementById("table1");
        //清楚测试数据
        var tr = document.getElementById("test");
        tr.parentNode.removeChild(tr);
        //循环
        for (var i = 0; i < 5; i++) {
            var row = table.insertRow(1);
            for (var j = 0; j < 10; j++) {
                if(j<=7){
                    var td = row.insertCell(j);
                    td.innerHTML = "NEW CELL" + j;
                }else if(j==8){
                    var del = row.insertCell(8);
                    del.innerHTML = "<input type='button' onclick='NWS001.del(this)' value='删除'/ >";
                }
                else if (j == 9) {
                    var checkFlag = row.insertCell(9);
                    checkFlag.innerHTML = "<input type='checkbox' name='checkFlag'  / >";
                }
            }
        }
    },
    add: function () {
        var table = document.getElementById("table1");
        var row = table.insertRow(num);
        for (var j = 0; j < 10; j++) {
            if (j <= 7) {
                var td = row.insertCell(j);
                td.innerHTML = "NEW CELL" + j;
            } else if (j == 8) {
                var del = row.insertCell(8);
                del.innerHTML = "<input type='button' onclick='NWS001.del(this)' value='删除'/ >";
            }
            else if (j == 9) {
                var checkFlag = row.insertCell(9);
                checkFlag.innerHTML = "<input type='checkbox' name='checkFlag'  / >";
            }
        }
        num++;
    },
    del: function (obj) {
        var tr = obj.parentNode.parentNode;
        tr.parentNode.removeChild(tr);
        if(num>=2){
            num--;
        }
    },
    checkAll: function (value) {
        var arr = document.getElementsByName("checkFlag");
        for (var i = 0; i < arr.length;i++){
            if (value) {
                arr[i].checked = true;
            } else {
                arr[i].checked = false;
            }
        }
    },
    delAll: function () {
        var arr = document.getElementsByName("checkFlag");
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].checked) {
                // del(arr[i]);
                NWS001.del(arr[i]);
                i--;
            }
        }
    }
}