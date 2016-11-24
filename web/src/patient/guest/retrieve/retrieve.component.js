angular.
  module('retrieve').
  component('retrieve', {
      templateUrl: '/Patient/Angular/guest/retrieve/retrieve.template.html',
      controller: ['$scope', '$http', '$routeParams', 'Account', function ($scope, $http, $routeParams, Account) {

          $scope.email = "";
          $scope.password = "";

          $scope.message = "";

          $scope.retrieve = function () {
              $scope.message = "submiting...";
              Account.reset($scope.email, $scope.password, function (mes) {
                  $scope.message = mes;
              });
          };
      }]
  });
