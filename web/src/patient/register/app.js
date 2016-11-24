import angular from 'angular';

angular.module('app', [require('../../common/patient/account')])
    .controller('RegisterCtrl',['$scope', 'AccountService', function ($scope, AccountService) {

        $scope.confirmPassword = "";

        $scope.patient = {
            patientId: 0,
            firstName: "Test FN",
            lastName: "Last FN",
            dob: new Date(),
            emailAddress: "ravitejav+TNTTest2@gmail.com",
            addressLine: "Test Address",
            city: "Test City",
            stateId: 40,
            medicalRecordNumber: "TMMMERN83483",
            password: ""
        };

		$scope.error = "";
        $scope.submitting = false;

        $scope.signUp = function () {
            $scope.error = "";
            $scope.message = "";

            if ($scope.patient.password !== $scope.confirmPassword) {
                $scope.error = "the passwords doesn't match";
                return;
            }

            $scope.submitting = true;
            AccountService.addPatient($scope.patient, function (err) {
                $scope.submitting = false;
                if (err) {
                    $scope.error = err;
                } else {
                    location.href = '/patient/journey';
                }
            });
        };
    }]);