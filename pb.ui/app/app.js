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
var pbApp = angular
    .module("purplebricksuiApp", [
        "ngAnimate",
        "ngCookies",
        "ngResource",
        "ui.router",
        "ngSanitize",
        "ngTouch",
        "LocalStorageModule"
    ])
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
                    'navigationView@': {
                        templateUrl: "components/navigation/nav.html",
                        controller: 'NavigationCtrl',
                        controllerAs: 'navigation'
                    }
                }
            })
            .state("pb.home", {
                url: "/",
                views: {
                    'mainView@': {
                        templateUrl: "components/main/main.html",
                        controller: "MainCtrl",
                        controllerAs: "main"
                    }
                }
            })
            .state("pb.register", {
                url: "/register",
                views: {
                    'mainView@': {
                        templateUrl: "components/registration/reg.html",
                        controller: "RegistrationCtrl",
                        controllerAs: "registration"
                    }
                }
            })
            .state("pb.login", {
                url: "/login",
                views: {
                    'mainView@': {
                        templateUrl: "components/login/login.html",
                        controller: "LoginCtrl",
                        controllerAs: "login"
                    }
                }
            })
            .state("pb.buyer", {
                url: "/buyer",
                views: {
                    'mainView@' : {
                        templateUrl: "components/buyer/buyer.html",
                        controller: "BuyerCtrl",
                        controllerAs: "buyer"
                    }
                }
            })
        .state("pb.seller", {
            url: "/seller",
            views: {
                'mainView@': {
                    templateUrl: "components/seller/seller.html",
                    controller: "SellerCtrl",
                    controllerAs: "seller"
                }
            }
        });
    });
