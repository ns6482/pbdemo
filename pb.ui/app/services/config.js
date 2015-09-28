'use strict';

/**
 * @ngdoc service
 * @name purplebricksuiApp.config
 * @description
 * # config
 * Constant in the purplebricksuiApp.
 */
pbApp.constant('config', 42)
    .constant("ngAuthSettings", {
        apiServiceBaseUri: "http://localhost:32819/"
    })
    .constant("pbWebApi", {
        apiServiceBaseUri: "http://localhost:32822/api/"
    });

