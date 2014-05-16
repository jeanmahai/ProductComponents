/**
 * Created by jm96 on 14-5-12.
 */
define(["app","_baseController"],function(app){
    app.register.controller("testBaseController",function($scope,$controller){
        angular.extend(this,$controller("_baseController",{$scope:$scope}));
        $scope.my="i am child";
    });
});