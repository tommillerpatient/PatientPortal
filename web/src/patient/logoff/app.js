//import angular from 'angular';

angular.module('app', [require('../../common/patient/account')])
    .controller('LogoffCtrl',['$scope', 'AccountService', function ($scope, AccountService) {

        AccountService.signOut();

        if(CMS){
            location.href = "/";
        }

    }]);