define(["app"],function(app){
    app.register.controller("ControlPanelController",
    function($scope,$http){
        var user={
            data:{},
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
            add: function () {
                var me = this;
                var q = $http.post("/ControlPanel/InsertUser", { data: me.data });
                q.success(function (data) {
                    console.info(data);
                });
            },
            remove:function(){},
            query: function () {
                console.info("query user");
                var me = this;
                var filter = {};
                filter.data = {
                    PageIndex: $scope.pager.index,
                    PageSize:$scope.pager.size
                };
                angular.extend(filter.data, me.data);
                var q = $http.post("/ControlPanel/QueryUsers", filter);
                q.success(function (res) {
                    console.info(res);
                    me.list = res;
                });
            }
        };
        $scope.user=user;

        $scope.pager=new N.Pager(1,10,function(){
            user.query();
        });
    });
});