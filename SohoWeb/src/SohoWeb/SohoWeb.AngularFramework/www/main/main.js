/**
 * Created by Jeanma on 14-5-5.
 */
(function () {

    //config
    window["appConfig"]={

        //定义是否在http的时候显示loading
        showLoading:true,

        //这个值可以缺省
        loadingDom:document.getElementById("divLoading"),

        //定义需要依赖的js文件
        angularModualJS:["angularAMD"
            , "angular-route"
            //, "ng-grid"
            , "angular-cookies"
            , "angular-date"],

        //定义需要依赖的angular modual
        angularModualNames:["ngRoute"//
            // , "ngGrid"
            , "ngCookies"
            , "NProvider"
            , "ui.date"],
        index: "/home",
        viewBasePath:"views/"
    };
    //url route
    window["appRouteUrl"]={
        home:{
            routeUrl:"/home",
            templateUrl:"views/home.html",
            controller:"homeController"
        },
        dataGrid1:{
            routeUrl: "/dataGrid1",
            templateUrl: "views/dataGrid1.html",
            controller:"dataGrid1Controller"
        },
        demo:{
            routeUrl:"/demo",
            templateUrl: "views/dynamicLoadControllerAndView.html",
            controller:"DynamicController"
        },
        datepicker:{
            routeUrl:"/datepicker",
            templateUrl: "views/datepicker.html",
            controller:"datepickerController"
        },
        testBaseController:{
            routeUrl:"/testBaseController",
            templateUrl: "views/testBaseController.html",
            controller:"testBaseController"
        },
        //默认跳转页面
        otherwise:{
            redirectTo:"/home"
        }
    };

    function getShortDateString() {
        var date = new Date();
        //cache 1 hour
        //return date.getFullYear()+date.getMonth()+date.getDate()+date.getHours();

        //no cache
        return Math.random();
    }

    function loadCss(url) {
        var link = document.createElement("link");
        link.type = "text/css";
        link.rel = "stylesheet";
        link.href = url;
        document.getElementsByTagName("head")[0].appendChild(link);
    }

    require.config({
        baseUrl: "controllers",
        paths: {
            'angular': '../bower_components/angular/angular.min',
            'angular-route': '../bower_components/angular-route/angular-route.min',
            'angularAMD': '../bower_components/angularAMD/angularAMD.min',
            'angular-cookies': '../bower_components/angular-cookies/angular-cookies.min',
            'jquery-ui': "../bower_components/jquery-ui/ui/jquery-ui",
            'jquery-ui-core': "../bower_components/jquery-ui/ui/minified/jquery.ui.core.min",
            'jquery-ui-datepicker': "../bower_components/jquery-ui/ui/minified/jquery.ui.datepicker.min",
            "angular-date": "../bower_components/angular-ui-date/src/date",
            "jquery-ui-datepicker-zh-cn": "../bower_components/jquery-ui/ui/i18n/jquery.ui.datepicker-zh-CN",
            'jquery': '../bower_components/jquery/jquery.min',
            'ng-grid': "../bower_components/ng-grid/ng-grid-2.0.11.min",

            'app': "../main/app"
        },

        // Add angular modules that does not support AMD out of the box, put it in a shim
        shim: {
            'angular': {
                deps: ["jquery"],
                init: function () {
                    loadCss("main/main.css");
                }
            },
            'angularAMD': ['angular'],
            'angular-route': ['angular'],
            "ng-grid": {
                deps: ["angular", "jquery"],
                init: function () {
                    loadCss("bower_components/ng-grid/ng-grid.min.css");
                }
            },
            "angular-cookies": ["angular"],
            "jquery-ui-core": ["jquery"],
            "jquery-ui-datepicker-zh-cn": ["jquery-ui-core", "jquery-ui-datepicker"],
            "jquery-ui-datepicker": ["jquery-ui-core"],
            "jquery-ui": ["jquery"],
            "angular-date": {
                deps: ["angular", "jquery-ui-core", "jquery-ui-datepicker"],
                init: function (a, b, c) {
                    loadCss("bower_components/jquery-ui/themes/ui-darkness/jquery-ui.min.css");
                }
            },
            'app':{
                deps:["angular"],
                init:function(){

                }
            }
        }

        // kick start application
        ,deps: ['app']
        //set javascript no cache
        , urlArgs: "_=" + getShortDateString()
    });
})();
