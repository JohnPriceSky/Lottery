var app = angular.module('app', ['ngRoute']);
var host = 'http://localhost:52574';
var userId = 0;
var userName = '';
var lotteryId = 0;

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/app/templates/login.html',
            controller: 'login'
        })
        .when('/admin', {
            templateUrl: '/app/templates/admin.html',
            controller: 'admin'
        })
        .when('/dashboard', {
            templateUrl: '/app/templates/dashboard.html',
            controller: 'dashboard'
        })
        .when('/lottery', {
            templateUrl: '/app/templates/lottery.html',
            controller: 'lottery'
        })
}]);