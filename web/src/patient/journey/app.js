function getActive(task) {
    return task.status == 3;
}

function getPercentage(step) {
    var count = 0;
    for (var i = 0; i < step.patientTaskList.length; i++) {
        var task = step.patientTaskList[i];
        if (getActive(task)) {
            ++count;
        }
    }
    return count ? Math.floor(100 * (count / 8)) : 0;
}

angular.module('app', [require('../../common/patient/account'), require('../../common/patient/pathway')])
    .controller('BannerCtrl', ['$scope', 'AccountService', 'PathwayService', function ($scope, AccountService, PathwayService) {

        $scope.percentage = "0%";

        var patient = AccountService.getPatient();
        if (patient) {
            var patientInfo = patient.patientInformationDto;
            $scope.firstName = patientInfo.firstName;

            var pathway = patient.patientInformationDto.pathwaysDetails[0];


            PathwayService.get(patient.patientId, pathway.pathwayId, function (res) {
                $scope.percentage = getPercentage(res.patientStepDetailList[0]) + '%';
            });
        }

    }])
    .controller('JourneyCtrl', ['$scope', 'AccountService', 'PathwayService', function ($scope, AccountService, PathwayService) {

        var patient = AccountService.getPatient();
        if (patient) {
            var pathway = patient.patientInformationDto.pathwaysDetails[0];

            PathwayService.get(patient.patientId, pathway.pathwayId, function (res) {
                $scope.step = res.patientStepDetailList[0];
            });
        }

        $scope.getActiveCss = function (index) {
            if ($scope.step) {
                var active = getActive($scope.step.patientTaskList[index]);
                return {red: !active, green: active};
            }
            return {};
        };

    }])
    .controller('ProgressCtrl', ['$scope', 'AccountService', 'PathwayService', function ($scope, AccountService, PathwayService) {

        $scope.percentage = "0%";
        $scope.percentageStyle = {width: $scope.percentage};

        var patient = AccountService.getPatient();
        if (patient) {
            var pathway = patient.patientInformationDto.pathwaysDetails[0];


            PathwayService.get(patient.patientId, pathway.pathwayId, function (res) {
                $scope.percentage = getPercentage(res.patientStepDetailList[0]) + '%';
                $scope.percentageStyle = {width: $scope.percentage};
            });
        }

    }]);