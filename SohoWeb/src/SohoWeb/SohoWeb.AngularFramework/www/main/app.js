/**
 * Created by Jeanma on 14-5-5.
 */
define(window["appConfig"].angularModualJS, function (angularAMD) {
    var cfg = window["appConfig"];
    var app = angular.module("app", cfg.angularModualNames);

    //config $N
    app.run(function ($N) {
        $N.showLoading = cfg.showLoading;
        if (cfg.loadingDom) {
            $N.dom = cfg.loadingDom;
        }
    });

    //config url route
    //#region 静态配置路由
    var routeOps = window["appRouteUrl"];
    app.config(["$routeProvider", function ($routeProvider) {
        for (var ops in routeOps) {
            if (ops === "otherwise") {
                $routeProvider.otherwise(routeOps[ops]);
                continue;
            }
            var routeUrl = routeOps[ops].routeUrl;
            delete routeOps[ops].routeUrl;
            $routeProvider.when(routeUrl, angularAMD.route(routeOps[ops]));
        }
    }]);
    //#endregion

    //#region 动态路由
    //动态routing,目前已经禁用了,由于功能还不成熟,暂停使用
    //需要做的东西::controller/:view/:params
    //1.动态去加载对应的view
    //2.动态去加载对应的controller
    //3.处理参数
    //modify angularAMD line angularAMD.prototype.route, line 108~111

    //#endregion
    //function getController(url) {
    //    var index = url.indexOf("#");
    //    var sub = url.substring(index + 1);
    //    var strs = sub.split("/");
    //    if (strs.length > 1) {
    //        var ctlName = strs[1] + "Controller";
    //        console.info("controller:" + ctlName);
    //        return ctlName;
    //    }
    //    throw new Error("controller不存在");
    //}
    //app.config(["$routeProvider", function ($routeProvider, $routeParams) {
    //    $routeProvider.
    //        when("/:controller/:view", angularAMD.route({
    //            templateUrl: function ($routeParams) {
    //                var view = $routeParams.view;
    //                if (view) {
    //                    view = view.replace("-", "/");
    //                    return appConfig.viewBasePath + view + ".html";
    //                }
    //                throw new Error("view不存在");
    //            },
    //            controller: function () {
    //                console.info("get controller");
    //                return getController(window.location.href);
    //            }
    //        })).
    //        when("/:controller", angularAMD.route({
    //            templateUrl: function ($routeParams) {
    //                var view = $routeParams.controller
    //                if (view) {
    //                    return appConfig.viewBasePath + view + ".html";
    //                }
    //                throw new Error("view不存在");
    //            },
    //            controller: function () {
    //                console.info("get controller");
    //                return getController(window.location.href);
    //            }
    //        })).
    //        otherwise({redirectTo:appConfig.index});
    //}]);


    //interceptor http
    app.factory("httpInterceptor", ["$N", function ($N) {
        return{
            'request': function (config) {
                // do something on success
                //处理自定义headers
                config.headers = {
                    "x-newegg-mobile-cookie": window.localStorage.getItem("x-newegg-mobile-cookie")
                };
                //处理loading
                $N.loading(config);
                return config || $q.when(config);
            },
            'response': function (response) {
                // do something on success
                //处理自定义的headers
                var mobileCookie = response.headers("x-newegg-mobile-cookie");
                if (mobileCookie && mobileCookie != "") {

                }
                window.localStorage.setItem("x-newegg-mobile-cookie", mobileCookie);
                //处理loaded
                $N.loaded(response);

                return response || $q.when(response);
            }
        };
    }]);
    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push("httpInterceptor");
    });


    //start
    angularAMD.bootstrap(app);

    return app;
});
//javascript 1.8 及以上的功能 在移动端部分浏览器没有此功能
if (!Function.prototype.bind) {
    Function.prototype.bind = function (oThis) {
        if (typeof this !== "function") {
            // closest thing possible to the ECMAScript 5 internal IsCallable function
            throw new TypeError("Function.prototype.bind - what is trying to be bound is not callable");
        }

        var aArgs = Array.prototype.slice.call(arguments, 1),
            fToBind = this,
            fNOP = function () {
            },
            fBound = function () {
                return fToBind.apply(this instanceof fNOP && oThis
                    ? this
                    : oThis,
                    aArgs.concat(Array.prototype.slice.call(arguments)));
            };

        fNOP.prototype = this.prototype;
        fBound.prototype = new fNOP();

        return fBound;
    };
}


angular.module("NProvider", ["ng"]).
    provider("$N", function () {
        function N() {
            this.showLoading = false;
            this.dom = null;
            this.timeout = null;
            this.width = null;
        };
        N.prototype = {
            loading: function (config) {
                if (this.showLoading) {
                    if (!this.dom) {
                        this.dom = document.createElement("div");
                        this.dom.innerHTML = "<div class='circle'></div><div class='circle1'></div>";
                        this.dom.setAttribute("class", "n-loading")

                        document.body.appendChild(this.dom);
                    }
                    if (this.timeout) {
                        clearTimeout(this.timeout);
                        this.timeout = null;
                    }
                    this.dom.style.right = "0px";
                }
            },
            loaded: function (response) {
                if (this.showLoading) {
                    if (!this.width) {
                        if (window.getComputedStyle)
                            this.width = parseInt(window.getComputedStyle(this.dom).width);
                        else if (this.dom.currentStyle) {
                            this.width = parseInt(this.dom.currentStyle.width);
                        }
                    }

                    function hideLoading() {
                        this.dom.style.right = "-" + this.width + "px";
                    };
                    this.timeout = setTimeout(hideLoading.bind(this), 1500);
                }
            }
        };
        this.$get = function () {
            return new N();
        };
    });