angular.
  module('save').
  component('save', {
      templateUrl: '/Patient/Angular/guest/save/save.template.html',
      controller: ['$scope', '$http', '$routeParams', 'Account', function ($scope, $http, $routeParams, Account) {

          $scope.patient = {
              patientId: 0,
              firstName: "Test FN",
              lastName: "Last FN",
              dob: new Date(),
              emailAddress: "ravitejav+TNTTest2@gmail.com",
              addressLine: "Test Address",
              city: "Test City",
              stateId: 40,
              medicalRecordNumber: "TMMMERN83483"
          };

          $scope.message = "";

          $scope.save = function () {
              $scope.message = "submiting...";
              Account.addPatient($scope.patient, function (mes) {
                  $scope.message = mes;
              });
          };
      }]
  });
