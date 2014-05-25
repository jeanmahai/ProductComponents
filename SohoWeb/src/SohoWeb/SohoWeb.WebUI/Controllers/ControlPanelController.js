define(["app"], function (app) {
    app.register.controller("ControlPanelController",
    function ($scope, $http) {
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
            updatePsw: function () {
                var me = this;
                var q = $http.post("/ControlPanel/ModifyPassword", { data: me.data });
                q.success(function (data) {
                    console.info(data);
                });
            },
            save: function () {
                //如果有sysno就是修改否则就是添加
                var me = this;
                $http.post("/ControlPanel/InsertUser", me.data).success(function (data) {
                    console.info(data);
                    alert("添加成功");
                }).catch(function () {
                    console.info(arguments);
                });
            },
            remove: function () { },
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
            }
        };
        $scope.user = user;

        $scope.pager = new N.Pager(1, 10, function () {
            user.query();
        });
    });
});