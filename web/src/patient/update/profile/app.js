var app = CMS
    ? angular.module('app')
    : angular.module('app', [require('../../../common/patient/account'), require('../../../common/patient/pathway')]);

app.controller('ProfileCtrl',['$scope', 'AccountService', function ($scope, AccountService) {

        $scope.error = "";
        $scope.message = "";
        $scope.submitting = false;

        var patient = AccountService.getPatient();
        var patientInfo = patient.patientInformationDto;

        $scope.patient = {
            patientId: patient.patientId,
            firstName: patientInfo.firstName,
            lastName: patientInfo.lastName,
            dob: moment(patientInfo.dateOfBirth).toDate(),
            emailAddress: patientInfo.emailAddress,
            addressLine: patientInfo.address1,
            city: patientInfo.city,
            stateId: patientInfo.state.item1,
            medicalRecordNumber: patientInfo.medicalRecordNumber,
            cellPhone: patientInfo.cellPhone,
            homePhone: patientInfo.homePhone
        };

        $scope.save = function () {
            $scope.error = "";
            $scope.message = "";
            $scope.submitting = true;
            AccountService.updatePatient($scope.patient, function (err) {
                $scope.submitting = false;
                if (err) {
                    $scope.error = err;
                } else {
                    $scope.message = "Done!";
                }
            });
        };

    }]);