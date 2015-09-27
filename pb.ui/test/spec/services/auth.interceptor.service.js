'use strict';

describe('Service: auth.interceptor.service', function () {

  // load the service's module
  beforeEach(module('purplebricksuiApp'));

  // instantiate service
  var auth.interceptor.service;
  beforeEach(inject(function (_auth.interceptor.service_) {
    auth.interceptor.service = _auth.interceptor.service_;
  }));

  it('should do something', function () {
    expect(!!auth.interceptor.service).toBe(true);
  });

});
