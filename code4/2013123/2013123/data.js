//------------1、数据准备-------
//1.1捐款单位数据
var OrgList = [{
    id: 0,
    name: "土豪基金"
}, {
    id: 1,
    name: "壹基金"
}, {
    id: 2,
    name: "宋庆龄基金"
}, {
    id: 3,
    name: "郭美美基金"
}];
//1.2受捐单位数据
var MoneyList = [{
    id: 1,
    pName: "马xx",
    orgid: 3,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 2,
    pName: "张xx",
    orgid: 2,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 3,
    pName: "林xx",
    orgid: 1,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 4,
    pName: "邹xx",
    orgid: 0,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 5,
    pName: "马xx",
    orgid: 3,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 6,
    pName: "张xx",
    orgid: 2,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 7,
    pName: "林xx",
    orgid: 1,
    money: 100000,
    date: "2013-12-12"
}, {
    id: 8,
    pName: "邹xx",
    orgid: 0,
    money: 100000,
    date: "2013-12-12"
}];
//1、获取元素方法
function gel(id) {
    return document.getElementById(id);
}
//2、根据id得到捐款单位对象
function getOrgObjById(orgid) {
    for (var i = 0; i < OrgList.length; i++) {
        //判断当前循环到对象id是不是传入的id
        if (OrgList[i].id == orgid) {
            //如果条件匹配返回当前对象
            return OrgList[i];
        }
    }
}
//2、根据id得到捐款数据对象
function getMoneyObjById(id) {
    for (var i = 0; i < MoneyList.length; i++) {
        //判断当前循环到对象id是不是传入的id
        if (MoneyList[i].id == id) {
            //如果条件匹配返回当前对象
            return MoneyList[i];
        }
    }
}
//3、删除数组中的指定元素
function delMoneyListObj(id) {
    //记录删除元素的下标
    var index = -1;
    //循环得到删除元素的下标
    for (var i = 0; i < MoneyList.length; i++) {
        //如果当前元素的id等于传入的id 那么i就是需要的下标
        if (MoneyList[i].id == id) {
            index = i;
            break;
        }
    }
    ////从要删除的元素的位置开始循环，把后面的元素往前移一位
    //for (var i = index; i < MoneyList.length; i++) {
    //    //移动方式就是下标加1
    //    // MoneyList[i] 需要覆盖的元素
    //    //MoneyList[i + 1]; 用来覆盖的元素
    //    MoneyList[i] = MoneyList[i + 1];
    //}
    ////最后长度减1
    //MoneyList.length -= 1;
    //splice 删除或者是添加元素
    //第一个参数是开始位置
    //第二个参数是删除元素 个数 可以是0 
    //后面所以参数都表示是需要新增的元素
    MoneyList.splice(index, 1);
}
//4、根据受捐单位id查询数据
function getMoneyListByOrgid(orgid) {
    //记录查询到数据的数组
    var selectArr = [];
    //循环受捐单位的数组
    for (var i = 0; i < MoneyList.length; i++) {
        //如果当前循环的到对象的orgid与传入的orgid相同，表示就是我们要查询的数据，把这个数据记录在selectArr数组
        if (MoneyList[i].orgid == orgid || orgid == -1) {
            selectArr[selectArr.length] = MoneyList[i];
        }
    }
    //返回装载了查询结果的数组
    return selectArr;
}
var pageindex = 0;
var pagesize = 5;
var pagecount = 0;
//5、计算总页数
function getCount() {
    //使用天花板函数计算总页数
    pagecount = Math.ceil(MoneyList.length / pagesize);
    gel("count").innerHTML = pagecount;
}
//6、得到下一页的数据
function getNextPageData() {
    //记录当前页的数据
    var pageList = [];
    //判断获取的页有没有超出总页数
    pageindex++;
    if (pageindex > pagecount) {
        alert("已经是最后一页了！！");
        pageindex--;
        return;
    }
    //计算当前页的开始位置 
    var start = (pageindex - 1) * pagesize;
    //计算当前页的结束位置  如果当前页*页容量大于了数据总长度，那么结束的下标就是数组的长度
    var end = pageindex * pagesize > MoneyList.length ? MoneyList.length : pageindex * pagesize;
    //循环获得当前页的数据 也就是开始于结束之间的数据
    for (var i = start; i < end; i++) {
        pageList[pageList.length] = MoneyList[i];
    }
    gel("pageindex").innerHTML = pageindex;
    return pageList;
}
//7、得到上一页的数据
function getPrePageData() {
    //记录当前页的数据
    var pageList = [];
    //判断获取的页有没有超出总页数
    pageindex--;
    if (pageindex < 1) {
        alert("已经是第一页了！！");
        pageindex++;
        return;
    }
    //计算当前页的开始位置 
    var start = (pageindex - 1) * pagesize;
    //计算当前页的结束位置  如果当前页*页容量大于了数据总长度，那么结束的下标就是数组的长度
    var end = pageindex * pagesize;
    //循环获得当前页的数据 也就是开始于结束之间的数据
    for (var i = start; i < end; i++) {
        pageList[pageList.length] = MoneyList[i];
    }
    gel("pageindex").innerHTML = pageindex;
    return pageList;
}
//8根据id更新数组中的值
function updateMoneyObj(id, newObj) {
    for (var i = 0; i < MoneyList.length; i++) {
        //如果当前循环到的对象的id与传入的id 相同 ，
        if (MoneyList[i].id == id) {
            //则使用传入的对象覆盖当前对象;
            MoneyList[i] = newObj;
            break;
        }
    }
}
//9加载当前页数据
function reloadData() {
    EmptyTable();
    //记录当前页的数据
    var pageList = [];
    //判断获取的页有没有超出总页数
    //计算当前页的开始位置 
    var start = (pageindex - 1) * pagesize;
    //计算当前页的结束位置  如果当前页*页容量大于了数据总长度，那么结束的下标就是数组的长度
    var end = pageindex * pagesize > MoneyList.length ? MoneyList.length : pageindex * pagesize;
    //循环获得当前页的数据 也就是开始于结束之间的数据
    for (var i = start; i < end; i++) {
        pageList[pageList.length] = MoneyList[i];
    }
    gel("pageindex").innerHTML = pageindex;
    return pageList;
}