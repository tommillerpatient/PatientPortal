angular.module('pathway', [])
    .service('PathwayService', ['$http', 'AccountService', function ($http, AccountService) {


        $http.defaults.useXDomain = true;
        $http.defaults.headers.common = { 'Access-Control-Allow-Origin': '*' };
        delete $http.defaults.headers.common["X-Requested-With"];


        var pathway = null;
        var queue = [];


        function get(patientId, pathwayId, cb) {

            if (pathway) {
                cb(pathway);
                return;
            }

            queue.push(cb);
            if(queue.length > 1) return;

            var req = {
                method: 'GET',
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                }
            };

            req.url = SERVICE_URL +  'api/patient/pathway/' + patientId + '/' + pathwayId;

            $http(req).then(function (res) {

                pathway = res.data;
                for (var i = 0; i < queue.length; i++) {
                    queue[i](pathway);
                }
                queue = null;
            }).catch(function (err) {
                if(CMS){
                    AccountService.signOut();
                    location.href = "/";
                }else {
                    alert(JSON.stringify(err));
                }
            });

        }

        function getTask(patientId, pathwayId, stepId, taskId, cb) {
            get(patientId, pathwayId, function () {

                var steps = pathway.patientStepDetailList;
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