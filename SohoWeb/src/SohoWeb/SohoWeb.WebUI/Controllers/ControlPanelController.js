define(["app"],function(app){
    app.register.controller("ControlPanelController",
    function($scope,$http){
        var user={
            data:{},
            list:[],
            update:function(){},
            updatePsw:function(){},
            add:function(){},
            remove:function(){},
            query:function(){
                alert("query");
            }
        };
        $scope.user=user;

        $scope.pager=new N.Pager(1,10,function(){
            user.query();
        });
    });
});