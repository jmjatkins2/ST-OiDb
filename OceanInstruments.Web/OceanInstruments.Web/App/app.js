var app = angular.module('oceanInstruments', [
    'auth0',
    'ngRoute', 'ui.bootstrap',
    'angular-storage', 'angular-jwt', 'ngCookies' /* required for auth0 */
])
.config(function myAppConfig ($routeProvider, authProvider, $httpProvider, $locationProvider, jwtInterceptorProvider) {
    $routeProvider
      .when('/#', {
          controller: 'calibrationsController',
          templateUrl: 'views/calibrations.html',
          requiresLogin: false
      })
      .when('/login', {
          controller: 'loginController',
          templateUrl: 'views/login.html'
      })
      .when('/calibrations', {
          controller: 'calibrationsController',
          templateUrl: 'views/calibrations.html',
          requiresLogin: false
      })
      .otherwise({
          redirectTo: '/#'
      });

    authProvider.init({
        domain: 'oceaninstruments.auth0.com',
        clientID: '3oxfyEqFp3WIEzpLXShhPqoGidyI5Kd5',
        //callbackUrl: location.href,
        loginUrl: '/login'
    });

    // Add a simple interceptor that will fetch all requests and add the jwt token to its authorization header.
    jwtInterceptorProvider.tokenGetter = function (store) {
        return store.get('token');
    };
    $httpProvider.interceptors.push('jwtInterceptor');
})
.run(function ($rootScope, auth, store, jwtHelper, $location) {
    // This events gets triggered on refresh or URL change, and ensures authentication
    $rootScope.$on('$locationChangeStart', function () {
        if (!auth.isAuthenticated) {
            var token = store.get('token');
            if (token) {
                if (!jwtHelper.isTokenExpired(token)) {
                    auth.authenticate(store.get('profile'), token);
                } else {
                    $location.path('/login');
                }
            }
        }
    });
})
.controller('mainController', function ($scope, auth, $location, store) {

    //just required for printing out name
    $scope.auth = auth;

    $scope.logout = function () {
        auth.signout();
        store.remove('profile');
        store.remove('token');
        $location.path('/login');
    };
})
;