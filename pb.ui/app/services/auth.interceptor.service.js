'use strict';

/**
 * @ngdoc service
 * @name purplebricksuiApp.auth.interceptor.service
 * @description
 * # auth.interceptor.service
 * Service in the purplebricksuiApp.
 */
angular.module('purplebricksuiApp')
  .factory('authInterceptorService', ['$q', '$injector', '$location', 'localStorageService', function ($q, $injector, $location, localStorageService) {

      var authInterceptorServiceFactory = {};

      var request = function (config) {

          config.headers = config.headers || {};

          var authData = localStorageService.get('authorizationData');
          if (authData) {
              config.headers.Authorization = 'Bearer ' + authData.token;
          }

          return config;
      }

      var responseError = function (rejection) {
          if (rejection.status === 401) {
              var authService = $injector.get('authService');
              //var authData = localStorageService.get('authorizationData');

              //didn't have time for RT's, but this would be required, for now if the AT expires just redirect to login page
              //if (authData) {
              //    if (authData.useRefreshTokens) {
              //        $location.path('/refresh');
              //        return $q.reject(rejection);
              //    }
              //}
              authService.logOut();
              $location.path('/login');
          }
          return $q.reject(rejection);
      }

      authInterceptorServiceFactory.request = request;
      authInterceptorServiceFactory.responseError = responseError;

      return authInterceptorServiceFactory;
  }]);