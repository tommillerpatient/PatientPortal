import angular from 'angular';

angular.module('app', [require('../../common/patient/account')])
    .controller('LoginCtrl',['$scope', 'AccountService', function ($scope, AccountService) {

        if(AccountService.auth() && !DEBUG){
            location.href = '/patient/journey';
        }

        $scope.email = "TNTTest+1@gmail.com";
        $scope.password = "12345678",
            $scope.error = "";
        $scope.submitting = false;

        $scope.signIn = function () {
            $scope.error = "";
            $scope.submitting = true;
            AccountService.signIn($scope.email, $scope.password, function (err) {
                $scope.submitting = false;
                if (err) {
                    $scope.error = err;
                } else {

                    if(DEBUG){
                        alert("done");
                    }else {
                        location.href = '/patient/journey';
                    }
                }
            });
        };
    }]);