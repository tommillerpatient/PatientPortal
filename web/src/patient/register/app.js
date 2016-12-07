angular.module('app', [require('../../common/patient/account')])
    .controller('RegisterCtrl',['$scope', 'AccountService', function ($scope, AccountService) {

        var journeyUrl = '/patient/journey';

        $scope.confirmPassword = "";

        $scope.patient = {
            patientId: 0,
            firstName: "",
            lastName: "",
            dob: new Date(),
            emailAddress: "",
            addressLine: "Address",
            city: "City",
            stateId: 40,
            medicalRecordNumber: "TMMMERN83483",
            password: ""
        };

		$scope.error = "";
        $scope.submitting = false;

        $scope.signUp = function () {
            $scope.error = "";
            $scope.message = "";

            if ($scope.patient.emailAddress != $scope.confirmEmail) {
                $scope.error = "the emails doesn't match";
                return;
            }

            if ($scope.patient.password != $scope.confirmPassword) {
                $scope.error = "the passwords doesn't match";
                return;
            }

            $scope.submitting = true;
            AccountService.addPatient($scope.patient, function (err) {
                $scope.submitting = false;
                if (err) {
                    $scope.error = err;
                } else {
                    location.href = journeyUrl;
                }
            });
        };
    }]);