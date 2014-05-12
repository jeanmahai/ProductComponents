/**
 * Created by jm96 on 14-5-12.
 */
define(["app"], function (app) {
    app.register.controller("baseController", function ($scope) {
        $scope.test = function () {
            alert("base controller test.");
        };
    });
});