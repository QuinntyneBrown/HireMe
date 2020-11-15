import { TestBed } from '@angular/core/testing';

import { EmployeersService } from './employeers.service';

describe('EmployeersService', () => {
  let service: EmployeersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
