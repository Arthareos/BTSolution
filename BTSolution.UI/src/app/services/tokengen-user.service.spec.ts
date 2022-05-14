import { TestBed } from '@angular/core/testing';

import { TokengenUserService } from './tokengen-user.service';

describe('TokengenUserService', () => {
  let service: TokengenUserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TokengenUserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
