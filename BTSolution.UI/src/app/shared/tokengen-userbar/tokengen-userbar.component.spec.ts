import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TokengenUserbarComponent } from './tokengen-userbar.component';

describe('TokengenUserbarComponent', () => {
  let component: TokengenUserbarComponent;
  let fixture: ComponentFixture<TokengenUserbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TokengenUserbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TokengenUserbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
