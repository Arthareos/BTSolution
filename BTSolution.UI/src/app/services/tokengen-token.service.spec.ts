import { TestBed } from '@angular/core/testing';

import { TokengenTokenService } from './tokengen-token.service';

describe('TokengenTokenService', () => {
  let service: TokengenTokenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TokengenTokenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
