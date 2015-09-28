"use strict";

/**
 * @ngdoc service
 * @name purplebricksuiApp.data.service
 * @description
 * # data.service
 * Service in the purplebricksuiApp.
 */
pbApp.service("dataService", [
    "pbWebApi", "ngAuthSettings", "$http", function(pbWebApi, ngAuthSettings, $http) {


        var webApi = pbWebApi.apiServiceBaseUri;

        //seller's houses
        function getOwnerHouses() {

            var url = webApi + "house/owners";
            return $http.get(url);

        }

        //houses buyer can make offer on
        function getHouses() {

            var url = webApi + "house/houses";
            return $http.get(url);
        }

        function offer(house) {

            var requestBody = {
                amount: house.offerValue,
                numChains: 0 //leave out for now, not implemented
            }
            var url = webApi + "house/" + house.id + "/offer";

            return $http.post(url, requestBody);

        }

        function sellHouse(title, description, value) {
            var url = webApi + "house/sell";

            var requestBody = {
                "title": title,
                "description": description,
                "value" : value
            }
            
            return $http.post(url, requestBody);
        };

        function accept(offerId) {
            var url = webApi + "offer/" + offerId + '/accept';
            return $http.put(url);
        };
	  
	  var service = {
	      getOwnerHouses : getOwnerHouses,
	      getHouses: getHouses,
          sellHouse: sellHouse,
          offer: offer,
          accept: accept
	  }
	  
	  return service;
    // AngularJS will instantiate a singleton by calling "new" on this function
  }]);
