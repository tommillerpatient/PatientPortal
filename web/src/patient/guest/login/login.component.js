import angular from 'angular';

angular.
  module('login').
  component('login', {
      template: require('./login.template.html'),
      controller: ['$scope', '$http', '$routeParams', '$sce', 'AccountService', function ($scope, $http, $routeParams, $sce, AccountService) {

          $scope.email = "TNTTest+1@gmail.com";
          $scope.password = "12345678",
          $scope.error = "";
          $scope.submiting = false;

          $scope.signIn = function () {
              $scope.error = "";
              $scope.submiting = true;
              AccountService.signIn($scope.email, $scope.password, function (err) {
                  if (err) {
                      $scope.submiting = false;
                      $scope.error = err;
                  } else {
                      location.reload();
                  }
              });
          };
      }]
  });
