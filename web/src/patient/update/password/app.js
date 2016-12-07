var app = CMS
    ? angular.module('app')
    : angular.module('app', [require('../../../common/patient/account'), require('../../../common/patient/pathway')]);

app.controller('PasswordCtrl',['$scope', 'AccountService', function ($scope, AccountService) {

        var patient = AccountService.getPatient();

        $scope.currentPassword = "";
        $scope.newPassword = "";
        $scope.confirmPassword = "";

        $scope.error = "";
        $scope.message = "";

        $scope.submitting = false;

        $scope.reset = function () {
            $scope.error = "";
            $scope.message = "";

            if (!$scope.newPassword) {
                $scope.error = "'new password' field is required";
                return;
            }

            if ($scope.newPassword !== $scope.confirmPassword) {
                $scope.error = "the passwords doesn't match";
                return;
            }

            $scope.submitting = true;
            AccountService.reset(patient.patientInformationDto.emailAddress, $scope.currentPassword, $scope.newPassword, function (err) {
                $scope.submitting = false;
                if (err) {
                    $scope.error = err;
                } else {
                    $scope.message = "Done!";
                    $scope.currentPassword = "";
                    $scope.newPassword = "";
                    $scope.confirmPassword = "";
                }
            });
        };

    }]);