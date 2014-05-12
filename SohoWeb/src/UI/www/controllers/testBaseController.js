/**
 * Created by jm96 on 14-5-12.
 */
define(["app","baseController"],function(app){
    app.register.controller("testBaseController",function($scope,$controller){
        $scope.child=function(){
            alert("i am a child");
        };
        angular.extend(this,$controller("baseController",{$scope:$scope}));
        $scope.child2=function(){
            alert("i am a child2");
        };
    });
});