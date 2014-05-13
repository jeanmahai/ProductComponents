<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SohoWeb.AngularFramework.Test.www.index" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="bower_components/pure/pure-min.css" type="text/css" rel="stylesheet" />
    <script data-main="main/main.js" src="bower_components/requirejs/require.js"></script>

</head>
<body>
    <div class="pure-g layout">
        <!--left-->
        <div class="pure-u-4-24">
            <div class="pure-menu pure-menu-open">
                <a class="pure-menu-heading">Pure Css Demo</a>
                <ul>
                    <a href="#/home">home</a>
                    <a href="#/testBaseController">test base controller</a>
                    <a href="#/dataGrid1">pure table style</a>
                    <a href="#/angular-cookies">angular cookie</a>
                    <a href="#/datepicker">jquery ui datepicker</a>
                    <a href="#/demo">动态加载controller and view</a>
                    <a href="#/demo">错误处理</a>
                </ul>
            </div>
        </div>
        <!--right-->
        <div class="pure-u-20-24" ng-view>
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
