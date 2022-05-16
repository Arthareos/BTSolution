import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TokenBarComponent } from './token-bar.component';

describe('TokenBarComponent', () => {
  let component: TokenBarComponent;
  let fixture: ComponentFixture<TokenBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TokenBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TokenBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
