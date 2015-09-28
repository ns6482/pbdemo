'use strict';

/**
 * @ngdoc service
 * @name purplebricksuiApp.auth.service
 * @description
 * # auth.service
 * Service in the purplebricksuiApp.
 */
pbApp.factory('authService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', '$log', '$state', function ($http, $q, localStorageService, ngAuthSettings, $log, $state) {

      var serviceBase = ngAuthSettings.apiServiceBaseUri;
      var authServiceFactory = {};

      var authentication = {
          isAuth: false,
          userName: "",
          userType: ""
      };


      var saveRegistration = function (registration, type) {

          logOut();

          return $http.post(serviceBase + 'api/user/register/' + type, registration).then(function (response) {
              return response;
          });

      };

      var login = function (loginData) {


          var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

          //var deferred = $q.defer();

          return $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

              if (loginData.useRefreshTokens) {
                  localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, userType: response.user_type});
              }
              else {
                  localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, userType: response.user_type });
              }
              authentication.isAuth = true;
              authentication.userName = loginData.userName;
              authentication.userType = response.user_type;

              $log.debug('retrieved auth details:');
              $log.debug(authentication);

              return authentication;
              //deferred.resolve(response);

          }).error(function (err, status) {
              logOut();
              //deferred.reject(err);
          });

          //return deferred.promise;

      };

      var logOut = function () {

          localStorageService.remove('authorizationData');

          authentication.isAuth = false;
          authentication.userName = "";
          authentication.useRefreshTokens = false;
          authentication.userType = "";

      };

      authServiceFactory.saveRegistration = saveRegistration;
      authServiceFactory.login = login;
      authServiceFactory.logOut = logOut;
      authServiceFactory.authentication = authentication;

      return authServiceFactory;
  }]);