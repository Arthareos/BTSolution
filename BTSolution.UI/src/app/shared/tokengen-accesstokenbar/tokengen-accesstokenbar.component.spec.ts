import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TokengenAccesstokenbarComponent } from './tokengen-accesstokenbar.component';

describe('TokengenAccesstokenbarComponent', () => {
  let component: TokengenAccesstokenbarComponent;
  let fixture: ComponentFixture<TokengenAccesstokenbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TokengenAccesstokenbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TokengenAccesstokenbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
