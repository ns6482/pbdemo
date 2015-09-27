'use strict';

/**
 * @ngdoc service
 * @name purplebricksuiApp.data.service
 * @description
 * # data.service
 * Service in the purplebricksuiApp.
 */
angular.module('purplebricksuiApp')
  .service('data.service', function () {
	  
	  function registerUser(user, type) {
	  	  
	  }
	  
	  var service = {
		  registerUser: registerUser
	  }
	  
	  return service;
    // AngularJS will instantiate a singleton by calling "new" on this function
  });
