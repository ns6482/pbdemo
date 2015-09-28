'use strict';

/**
 * @ngdoc function
 * @name purplebricksuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the purplebricksuiApp
 */
pbApp.controller('RegistrationCtrl', ["$log","$state", "authService", function ($log, $state, authService) {


    var vm = this;

    vm.userName = "";
    vm.password = "";
    vm.confirmPassword = "";
    vm.userType = "buyer";
    vm.savedSuccessfully

   
    vm.register = function () {
        var registration = {
            "userName": vm.username,
            "password": vm.password,
            "confirmPassword" : vm.confirmPassword
        }

        authService.saveRegistration(registration, vm.userType).then(function () {

             vm.savedSuccessfully = true;

             //give user change to see the message
             var timer = $timeout(function () {
                 $timeout.cancel(timer);
                 $state.go('pb.login');
             }, 2000);

         }).catch(function(response) {
             var errors = [];
             console.log(response);
             //for (var key in response.data.modelState) {
             //    for (var i = 0; i < response.data.modelState[key].length; i++) {
             //        errors.push(response.data.modelState[key][i]);
             //    }
             //}
             vm.message = "Failed to register user due to:" + errors.join(' ');
         });
    }

}]);
