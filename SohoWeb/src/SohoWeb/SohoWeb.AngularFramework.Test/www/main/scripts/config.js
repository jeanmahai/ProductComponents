/**
 * Created by jm96 on 14-5-9.
 * appConfig 整个app的配置
 * appRouteUrl url route 配置项
 */
(function(){
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
            , "angular-date"
            , "N"],

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
})();
