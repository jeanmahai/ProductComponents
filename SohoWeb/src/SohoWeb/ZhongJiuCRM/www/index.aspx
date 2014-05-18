<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ZhongJiuCRM.www.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="bower_components/pure/pure-min.css" type="text/css" rel="stylesheet" />
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script data-main="main/main.js" src="bower_components/requirejs/require.js"></script>
</head>
<body>
    <div class="pure-g layout">
        <!--top-->
        <div class="pure-u-1-1 top">
            <div class="logo"></div>
            <div class="n-top-menu">
                <ul style="margin-top: 17px;">
                    <li><a href="login.aspx">
                        <img src="images/logout.png"
                            style="width: 15px; height: 15px; vertical-align: bottom; margin-right: 5px;" />退出</a></li>
                </ul>
            </div>
            <div class="n-top-menu2" style="float: none;">
                <ul style="margin-top: 17px;">
                    <li><a href="#/home">
                        <img src="images/home.png" />首页</a></li>
                    <li><a href="#/customer/add">
                        <img src="images/add_user.png" />添加新会员</a></li>
                    <li><a href="#">
                        <img src="images/weixin_logo.png" />我的微信(10000)</a></li>
                    <li><a href="#">
                        <img src="images/psw.png" />我的密码</a></li>

                </ul>
            </div>
            <div class="n-top-menu2" style="float: right;">
                <p style="color: white; margin-top: 19px;">xxx,你好,欢迎使用中酒网CRM!</p>
            </div>
        </div>
        <!--left-->
        <div class="pure-u-4-24 left">
            <div class="n-menu-header">系统菜单</div>
            <div class="n-seg"></div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a href="#" class="pure-menu-heading">
                    <img src="images/customers.png" />客户管理</a>
                <ul style="display: none;">
                    <li><a href="#/customer"><i></i>会员管理</a></li>
                    <li><a href="#/pure-table"><i></i>奖品管理</a></li>
                    <li><a href="#"><i></i>客户分类查询</a></li>
                </ul>
            </div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a class="pure-menu-heading">
                    <img src="images/care.png" />用户关怀</a>
                <ul style="display: none;">
                    <li><a href="#"><i></i>手动触发</a></li>
                    <li><a href="#"><i></i>触发器管理</a></li>
                </ul>
            </div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a class="pure-menu-heading">
                    <img src="images/info.png" />信息管理</a>
                <ul style="display: none;">
                    <li><a href="#"><i></i>短信配置</a></li>
                    <li><a href="#"><i></i>短信模板</a></li>
                    <li><a href="#"><i></i>短信查询</a></li>
                    <li><a href="#"><i></i>邮件配置</a></li>
                    <li><a href="#"><i></i>邮件模板</a></li>
                    <li><a href="#"><i></i>邮件查询</a></li>
                </ul>
            </div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a class="pure-menu-heading">
                    <img src="images/report.png" />数据分析</a>
                <ul style="display: none;">
                    <li><a href="#"><i></i>会员流失分析</a></li>
                    <li><a href="#"><i></i>日销售情况</a></li>
                    <li><a href="#"><i></i>月销售情况</a></li>
                    <li><a href="#"><i></i>前500位下单总金额排行</a></li>
                </ul>
            </div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a class="pure-menu-heading">
                    <img src="images/internet.png" />网络营销管理</a>
                <ul style="display: none;">
                    <li><a href="#"><i></i>微信</a></li>
                </ul>
            </div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a class="pure-menu-heading">
                    <img src="images/tool.png" />控制面板</a>
                <ul>
                    <li><a href="#"><i></i>用户管理</a></li>
                    <li><a href="#"><i></i>权限管理</a></li>
                    <li><a href="#"><i></i>角色管理</a></li>
                    <li><a href="#"><i></i>修改密码</a></li>
                    <li><a href="#"><i></i>日志管理</a></li>
                    <li><a href="#"><i></i>邮件服务配置</a></li>
                    <li><a href="#"><i></i>短信服务配置</a></li>
                </ul>
            </div>
        </div>
        <!--right-->
        <div class="pure-u-20-24 right" ng-view>
        </div>
    </div>
    <div id="divLoading" class="n-loading">
        <div>
            <div class="circle"></div>
            <div class="circle1"></div>
        </div>
    </div>
</body>
</html>
