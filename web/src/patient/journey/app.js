import angular from 'angular';
import moment from 'moment';

angular.module('app', [require('../../common/patient/account'),require('../../common/patient/pathway')])
    .controller('JourneyCtrl',['$scope', 'AccountService', 'PathwayService', function ($scope, AccountService, PathwayService) {

        $scope.error = "";
        $scope.message = "";
        $scope.submitting = false;

        $scope.statuses = {
            "1": "New",
            "2": "In Progress",
            "3": "Complete",
            "4": "Incomplete",
            "5": "Stalled",
            "6": "Skipped"
        };

        var patient = AccountService.getPatient();
        var pathway = patient.patientInformationDto.pathwaysDetails[0];


        $scope.submitting = true;
        PathwayService.get(patient.patientId, pathway.pathwayId, function (details) {
            $scope.details = details;
            $scope.submitting = false;
        });

        $scope.getTask = function (stepId, taskId) {
            PathwayService.getTask(patient.patientId, pathway.pathwayId, stepId, taskId, function (task, step) {
                $scope.task = task;
                $scope.step = step;

                var dueDate = moment(task.dueDate);
                var completedOn = moment(task.completedOn);
                $scope.dueDate = dueDate.isValid() ? dueDate.format('L') : '';
                $scope.completedOn = completedOn.isValid() ? completedOn.format('L') : '';
            });
        };


    }]);