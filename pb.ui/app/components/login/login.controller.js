"use strict";
pbApp.controller("LoginCtrl", [
    "$log", "$state", "authService", "ngAuthSettings", "$window", function($log, $state, authService, ngAuthSettings, $window) {

        var vm = this;
        vm.loginData = {
            userName: "",
            password: ""
        };

        vm.message = "";

        activate();

        function activate() {
            //clear any stored tokens when entering login screen
            authService.logOut();
        }

        vm.login = function() {

            return authService.login(vm.loginData).then(function(response) {
                    $log.debug(response);
                    if (authService.authentication.userType === "buyer") {
                        $log.debug("buyer");
                        $state.go("pb.buyer");
                    } else {
                        $state.go("pb.seller");
                        $log.debug("seller");
                    }
                    //$location.path('/orders');
                },
                function(err) {
                    $window.alert(err.error_description);
                });
        };


    }
]);