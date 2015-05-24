var app = angular.module('SocialNetwork', ['ngRoute']);

app.constant('baseUrl', 'http://softuni-social-network.azurewebsites.net/api');

app.config(function($routeProvider){
    $routeProvider.when('/', {
        templateUrl: 'partials/loginRegister.html'
    });
    $routeProvider.when('/login', {
        templateUrl: 'partials/login.html',
        controller: 'AuthController'
    });
    $routeProvider.when('/register', {
        templateUrl: 'partials/register.html',
        controller: 'AuthController'
    });
    $routeProvider.when('/home', {
        templateUrl: 'partials/home.html'
    });
    /*$routeProvider.otherwise({
        redirectTo: '/'
    });*/
});

/*
app.run(function($location){
    $location.path('/');
});
*/
