import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TokengenAccesstokencardComponent } from './tokengen-accesstokencard.component';

describe('TokengenAccesstokencardComponent', () => {
  let component: TokengenAccesstokencardComponent;
  let fixture: ComponentFixture<TokengenAccesstokencardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TokengenAccesstokencardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TokengenAccesstokencardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
