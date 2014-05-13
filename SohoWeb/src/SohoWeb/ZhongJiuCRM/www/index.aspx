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
                <ul>
                    <li><a href="#">
                        <img src="images/logout.png"
                            style="width: 15px; height: 15px; vertical-align: bottom; margin-right: 5px;" />退出</a></li>
                </ul>
            </div>
        </div>
        <!--left-->
        <div class="pure-u-4-24 left">
            <div class="n-menu-header">系统菜单</div>
            <div class="n-seg"></div>
            <div class="pure-menu pure-menu-open n-menu ">
                <a class="pure-menu-heading">
                    <img src="images/customers.png" />客户管理</a>
                <ul style="display: none;">
                    <li><a href="#/home"><i></i>会员管理</a></li>
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
                    <li><a href="#"><i></i>新浪微博</a></li>
                    <li><a href="#"><i></i>腾讯微博</a></li>
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
            <div class="pure-g">
                <div class="pure-u-1">
                    <div class="header">
                        <div class="title">欢迎使用中酒网CRM</div>
                    </div>
                </div>


                <div class="pure-u-1-2">
                    <div style="padding: 5px;">
                        <div style="padding:5px;border-top:1px solid #cbcbcb;border-left:1px solid #cbcbcb;border-right:1px solid #cbcbcb; background:rgb(212,227,250);color:black;font-size:1.1em;">订单总金额排行(top10)</div>
                        <table class="pure-table" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th>客户ID</th>
                                    <th>订单总金额</th>
                                    <th>最后下单日期</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="pure-u-1-2">
                    <div style="padding: 5px;">
                        <div style="padding:5px;border-top:1px solid #cbcbcb;border-left:1px solid #cbcbcb;border-right:1px solid #cbcbcb; background:rgb(212,227,250);color:black;font-size:1.1em; ">客户访问记录(最近10天)</div>
                        <table class="pure-table" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th>客户ID</th>
                                    <th>下单金额</th>
                                    <th>最后登录时间</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                                <tr>
                                    <td>test01</td>
                                    <td>&yen;10000000</td>
                                    <td>2012-09-01</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="pure-u-1">
                    <div style="padding: 5px;">
                        <div style="padding:5px; background:rgb(48,48,48);color:white;font-size:1.1em;">最新系统日志</div>
                        <table class="pure-table" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>标题</th>
                                    <th>内容</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>标题</td>
                                    <td>内容</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>标题</td>
                                    <td>内容</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>标题</td>
                                    <td>内容</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>标题</td>
                                    <td>内容</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>标题</td>
                                    <td>内容</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>标题</td>
                                    <td>内容</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="divLoading" class="n-loading">
</body>
</html>
