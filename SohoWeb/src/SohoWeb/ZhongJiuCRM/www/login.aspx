<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ZhongJiuCRM.www.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="bower_components/pure/pure-min.css" rel="stylesheet" />
    <style type="text/css">
        .frm { position: absolute; color: white; top: 346px; left: 288px; }
            .frm li { list-style: none; margin: 10px 0; }
            .frm label { width: 120px; text-align: right; display: inline-block; padding: 5px 5px; }
            .frm input { background: rgb(26,26,26); border: none; padding: 5px; width: 262px; }
        .btnLogin { position: absolute; top: 395px; left: 840px; color: rgb(95,11,15); text-decoration: none; font-weight: bold; font-size: 1.3em; }
    </style>
</head>
<body style="background: url('images/login_bg.png') no-repeat">
    <ul class="frm">
        <li>
            <label>用户名:</label><input type="text" placeholder="请输入用户名" /></li>
        <li>
            <label>密  码:</label><input type="text" placeholder="请输入密码" /></li>
    </ul>
    <a class="btnLogin" href="index.aspx">登录</a>
</body>
</html>
