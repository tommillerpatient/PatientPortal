import angular from 'angular';


angular.module('pathway', [])
    .service('PathwayService', ['$http', function ($http) {


        $http.defaults.useXDomain = true;
        $http.defaults.headers.common = { 'Access-Control-Allow-Origin': '*' };
        delete $http.defaults.headers.common["X-Requested-With"];


        var details = null;

        var _patientId = null;
        var _pathwayId = null;

        function get(patientId, pathwayId, cb) {

            if (details && _patientId == patientId && _pathwayId == pathwayId) {
                cb(details);
                return;
            }

            _patientId = patientId;
            _pathwayId = pathwayId;

            var req = {
                method: 'GET',
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                }
            };

            req.url = SERVICE_URL +  '/api/patient/pathway/' + patientId + '/' + pathwayId;

            $http(req).then(function (res) {

                details = res.data;
                cb(details);

            });

        }

        function getTask(patientId, pathwayId, stepId, taskId, cb) {
            get(patientId, pathwayId, function () {

                var steps = details.patientStepDetailList;
                for (var i = 0; i < steps.length; i++) {
                    if (steps[i].stepDetail.stepId == stepId) {
                        var tasks = steps[i].patientTaskList;
                        for (var j = 0; j < tasks.length; j++) {
                            if (tasks[j].patientTaskId == taskId) {
                                cb(tasks[j], steps[i]);
                                return;
                            }
                        }
                    }
                }
                cb({});

            });
        }

        return {
            get: get,
            getTask: getTask
        }
    }]);

module.exports = 'pathway';