"use strict";
pbApp.controller("NavigationCtrl", [
    "$log", "$state", "authService", function ($log, $state, authService) {

        var vm = this;
        vm.isActivated = false;

        activate();

        function activate() {

            vm.authentication = authService.authentication;
            console.log(vm.authentication);
            vm.activated = true;
        }

        vm.logout = function() {
            authService.logOut();
            $state.go('pb.home');
        }


    }
]);