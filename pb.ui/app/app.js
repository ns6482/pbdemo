"use strict";

var serviceBase = "http://localhost";
/**
 * @ngdoc overview
 * @name purplebricksuiApp
 * @description
 * # purplebricksuiApp
 *
 * Main module of the application.
 */
angular
    .module("purplebricksuiApp", [
        "pb.registration",
        "ngAnimate",
        "ngCookies",
        "ngResource",
        "ui.router",
        "ngSanitize",
        "ngTouch"
    ]).
    constant("ngAuthSettings", {
        apiServiceBaseUri: serviceBase,
    })
    .config(function($stateProvider, $urlRouterProvider, $httpProvider) {
        //Setup interceptor to add bear tokens to header, and redirect when unauth

        $httpProvider.interceptors.push("authInterceptorService");

        // For any unmatched url, redirect to /state1
        $urlRouterProvider.otherwise(function($injector) {
            var $state = $injector.get("$state");
            $state.go("pb.home");
        });
        //
        // Now set up the states
        $stateProvider
            .state("pb", {
                //url: "/",
                abstract: true,
                templateUrl: "index.html",
                views: {
                    'navigationView': {
                        templateUrl: "components/navigation/navigation.html",
                        //controller: 'NavigationController',
                        //controllerAs: 'navigation'
                    }
                }
            })
            .state("pb.home", {
                url: "/",
                views: {
                    'mainView@': {
                        templateUrl: "views/main.html",
                        controller: "MainCtrl",
                        controllerAs: "main"
                    }
                }
            })
            .state("pb.register", {
                url: "/register",
                views: {
                    'mainView@': {
                        templateUrl: "components/registration/registration.html",
                        controller: "RegistrationCtrl",
                        controllerAs: "registration"
                    }
                }
            });
    });
