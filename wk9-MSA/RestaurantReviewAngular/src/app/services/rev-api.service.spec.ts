import { TestBed } from '@angular/core/testing';

import { RevAPIService } from './rev-api.service';

describe('RevAPIService', () => {
  let service: RevAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RevAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
