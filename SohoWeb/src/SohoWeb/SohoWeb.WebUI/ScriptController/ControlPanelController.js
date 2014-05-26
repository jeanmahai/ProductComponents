define(["app", "_baseController"], function (app) {
    app.register.controller("ControlPanelController",
    function ($scope, $http, $routeParams, $controller) {
        angular.extend(this, $controller("_baseController", { $scope: $scope }));
        var user = {
            data: {},
            list: [],
            update: function () {
                var me = this;
                var q = $http.post("/ControlPanel/UpdateUser", { data: me.data });
                q.success(function (data) {
                    console.info(data);
                });
            },
            modifyPassword: function () {
                var me = this;
                if (me.data.NewPassword !== me.data.ConfirmPassword) {
                    alert("两次密码输入不一致,请重新输入");
                    return;
                }
                $http.post("/ControlPanel/ModifyPassword", me.data).success(function () {
                    alert("密码修改成功");
                });
            },
            save: function () {
                //如果有sysno就是修改否则就是添加
                var me = this;
                if (me.data.Password !== me.data.ConfirmPassword) {
                    alert("两次密码输入不一致,请重新输入");
                    me.data.Password = "";
                    me.data.ConfirmPassword = "";
                    return;
                }
                if (me.data.SysNo) {
                    var sysNo = parseInt(me.data.SysNo);
                    //edit
                    if (!isNaN(sysNo) && sysNo > 0) {
                        $http.post("/ControlPanel/UpdateUser", me.data).
                            success(function (res) {
                                alert("修改成功");
                            });
                        return;
                    }
                }

                //add
                $http.post("/ControlPanel/InsertUser", me.data).success(function (data) {
                    console.info(data);
                    alert("添加成功");
                }).catch(function () {
                    console.info(arguments);
                });
            },
            remove: function () {
                if (confirm("是否真的要删除?")) {
                    var me = this;
                    var sysNos = [];
                    angular.forEach(me.list, function (value) {
                        if (value.Checked) sysNos.push(value.SysNo);
                    });
                    console.info(sysNos);
                    $http.post("/ControlPanel/DeleteUser", sysNos).
                        success(function (res) {
                            alert("删除成功!");
                        });
                }


            },
            query: function () {
                console.info("query user");
                var me = this;
                var filter = {};
                filter = {
                    PageIndex: $scope.pager.index,
                    PageSize: $scope.pager.size
                };
                angular.extend(filter, me.data);
                $http.post("/ControlPanel/QueryUsers", filter).success(function (res) {
                    me.list = res.ResultList;
                    $scope.pager.setTotal(res.TotalCount);
                });
            },
            queryUserBySysNo: function () {
                var me = this;
                $http.post("/ControlPanel/GetUserByUserSysNo", me.data).
                    success(function (res) {

                        me.data = {
                            UserID: res.UserID,
                            UserName: res.UserName,
                            SysNo: res.SysNo
                        };
                    });
            }
        };
        $scope.user = user;

        $scope.pager = new N.Pager(1, 10, function () {
            user.query();
        });

        

        if ($routeParams.sysNo && $routeParams.sysNo > 0) {
            $scope.user.data.SysNo = $routeParams.sysNo;

            $scope.user.queryUserBySysNo();
        }
    });
});