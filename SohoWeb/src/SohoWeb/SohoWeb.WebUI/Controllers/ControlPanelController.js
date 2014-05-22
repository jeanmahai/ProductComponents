define(["app"],function(app){
    app.register.controller("ControlPanelController",
    function($scope,$http){
        var user={
            data:{},
            list: [],
            update: function () {
                var q = $http.post("/ControlPanel/UpdateUser", { data: this.data });
                q.success(function (data) {
                    console.info(data);
                });
            },
            updatePsw: function () {
                var q = $http.post("/ControlPanel/ModifyPassword", { data: this.data });
                q.success(function (data) {
                    console.info(data);
                });
            },
            add: function () {
                var q = $http.post("/ControlPanel/InsertUser", { data: this.data });
                q.success(function (data) {
                    console.info(data);
                });
            },
            remove:function(){},
            query: function () {
                console.info("query user");
                var q = $http.post("/ControlPanel/QueryUsers", {data:this.data});
                q.success(function (res) {
                    console.info(res);
                });
            }
        };
        $scope.user=user;

        $scope.pager=new N.Pager(1,10,function(){
            user.query();
        });
    });
});