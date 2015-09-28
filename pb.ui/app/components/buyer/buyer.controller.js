"use strict";
pbApp.controller("BuyerCtrl", [
    "$log", "$state", "authService", "dataService", "$window", function($log, $state, authService, dataService, $window) {

        var vm = this;

        vm.userName = authService.authentication.userName;

        vm.houses = [];
        vm.isActivated = false;

        activate();

        function activate() {
            $log.debug(vm.userName);

            getHouses();

            vm.isActivated = true;
        }

        vm.offer = function(house) {
            $log.debug("make offer:");
            $log.debug(house);

            dataService.offer(house).then(function(response) {
                getHouses(); //refresh
            }).catch(function(error) {
                $window.alert("oops something went wrong!");
                $log.debug(error);
            });
        }; //private functions

        function getHouses() {
            return dataService.getHouses().then(function(response) {
                vm.houses = response.data.results;
                angular.forEach(vm.houses, function(house) {
                    house.offerValue = angular.copy(house.value);
                });
                $log.debug(response.data.results);
            });
        }


    }
]);