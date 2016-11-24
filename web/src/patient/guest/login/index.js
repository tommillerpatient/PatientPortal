import angular from 'angular';

angular.module('login', [])
    .config(['$locationProvider', '$routeProvider', function config($locationProvider, $routeProvider) {

        $routeProvider.
            when('/login', {
                template: '<login></login>'
            });

    }]);

require('./login.component');

module.exports = 'login';
