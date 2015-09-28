"use strict";
pbApp.controller("SellerCtrl", [
    "$log", "$state", "authService", "dataService", "$window", function($log, $state, authService, dataService, $window) {

        var vm = this;

        vm.userName = authService.authentication.userName;

        vm.house = {
            title: "",
            description: "",
            amount: 0
        };
        vm.houses = [];
        vm.isActivated = false;

        activate();

        function activate() {
            $log.debug(vm.userName);

            getHouses();

            vm.isActivated = true;
        }

        vm.list = function() {
            if (vm.house.title && vm.house.description && vm.house.amount) {
                $log.debug(angular.toJson(vm.house));
                dataService.sellHouse(vm.house.title, vm.house.description, vm.house.amount).then(function () {
                    getHouses();
                    //would use growl or better flash notice here
                    $window.alert("house listed!");
                });
            } else {
                $window.alert("Enter all values to list house");
            }
        };

        vm.accept = function(offer) {
            return dataService.accept(offer.id).then(function() {
                getHouses();
                $window.alert("Accepted offer!");

            });
        };

        //private functions

        function getHouses() {
            return dataService.getOwnerHouses().then(function(response) {
                vm.houses = response.data.results;
                $log.debug(response.data.results);
            });
        }


    }
]);