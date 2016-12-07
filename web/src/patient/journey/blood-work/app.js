var app = CMS
    ? angular.module('app')
    : angular.module('app', [require('../../../common/patient/account'), require('../../../common/patient/pathway')]);


app.controller('BloodWorkCtrl', ['$scope', 'AccountService', 'PathwayService', function ($scope, AccountService, PathwayService) {

    if (location.href.indexOf('blood-work') == -1) return;

    var patient = AccountService.getPatient();
    if (patient) {
        var pathway = patient.patientInformationDto.pathwaysDetails[0];

        PathwayService.get(patient.patientId, pathway.pathwayId, function (pathway) {
            var step = pathway.patientStepDetailList[0];
            getTask(step.stepDetail.stepId, step.patientTaskList[0].patientTaskId)
        });
    }

    function getTask(stepId, taskId) {
        PathwayService.getTask(patient.patientId, pathway.pathwayId, stepId, taskId, function (task, step) {
            $scope.task = task;

            var dueDate = moment(task.dueDate);
            var dateStarted = moment(task.startedOn);
            $scope.dueDate = dueDate.isValid() ? 'Date due: ' + dueDate.format('L') : '';
            $scope.dateStarted = dateStarted.isValid() ? 'Date started:' + dateStarted.format('L') : '';
        });
    }

}]);