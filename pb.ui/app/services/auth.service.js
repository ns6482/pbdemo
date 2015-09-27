'use strict';

/**
 * @ngdoc service
 * @name purplebricksuiApp.auth.service
 * @description
 * # auth.service
 * Service in the purplebricksuiApp.
 */
angular.module('purplebricksuiApp')
  .factory('authService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

      var serviceBase = ngAuthSettings.apiServiceBaseUri;
      var authServiceFactory = {};

      var authentication = {
          isAuth: false,
          userName: "",
          //useRefreshTokens: false
      };

     
      var saveRegistration = function (registration) {

          logOut();

          return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
              return response;
          });

      };

      var login = function (loginData) {

          var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

          //if (loginData.useRefreshTokens) {
          //    data = data + "&client_id=" + ngAuthSettings.clientId;
          //}

          var deferred = $q.defer();

          $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

              if (loginData.useRefreshTokens) {
                  localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
              }
              else {
                  localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
              }
              authentication.isAuth = true;
              authentication.userName = loginData.userName;
              //authentication.useRefreshTokens = loginData.useRefreshTokens;

              deferred.resolve(response);

          }).error(function (err, status) {
              logOut();
              deferred.reject(err);
          });

          return deferred.promise;

      };

      var logOut = function () {

          localStorageService.remove('authorizationData');

          authentication.isAuth = false;
          authentication.userName = "";
          authentication.useRefreshTokens = false;

      };

      authServiceFactory.saveRegistration = saveRegistration;
      authServiceFactory.login = login;
      authServiceFactory.logOut = logOut;
      authServiceFactory.authentication = authentication;

      return authServiceFactory;
  }]);