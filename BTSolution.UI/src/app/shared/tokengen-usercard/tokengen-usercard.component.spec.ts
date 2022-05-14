import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TokengenUsercardComponent } from './tokengen-usercard.component';

describe('TokengenUsercardComponent', () => {
  let component: TokengenUsercardComponent;
  let fixture: ComponentFixture<TokengenUsercardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TokengenUsercardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TokengenUsercardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
