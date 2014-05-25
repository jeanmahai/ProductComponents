/**
 * Created by jm96 on 14-5-16.
 */
define(["app"],function(app){
    app.register.controller("_baseController",function($scope,$cookies){
        console.info("i am base controller");
        $scope._userName = "";
        //$scope._userSysNo = "";
        $scope._userID = "";
        console.info($cookies);
    });
});