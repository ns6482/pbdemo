'use strict';

describe('Service: data.service', function () {

  // load the service's module
  beforeEach(module('purplebricksuiApp'));

  // instantiate service
  var data.service;
  beforeEach(inject(function (_data.service_) {
    data.service = _data.service_;
  }));

  it('should do something', function () {
    expect(!!data.service).toBe(true);
  });

});
