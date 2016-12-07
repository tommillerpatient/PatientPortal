var app = CMS
    ? angular.module('app')
    : angular.module('app', [require('../../../common/patient/account'), require('../../../common/patient/pathway')]);


app.controller('JourneyRootCtrl', ['$scope', 'AccountService', 'PathwayService', function ($scope, AccountService, PathwayService) {

    var patient = AccountService.getPatient();
    if (patient) {
        var patientInfo = patient.patientInformationDto;
        $scope.firstName = patientInfo.firstName;

    }

}]);