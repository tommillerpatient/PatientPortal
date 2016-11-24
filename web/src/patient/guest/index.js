import angular from 'angular';

angular.module('guest', [
    require('./login')
]).config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {


    }
  ]);

module.exports = 'guest';