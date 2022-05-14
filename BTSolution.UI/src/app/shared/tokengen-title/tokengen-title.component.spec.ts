import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TokengenTitleComponent } from './tokengen-title.component';

describe('TokengenTitleComponent', () => {
  let component: TokengenTitleComponent;
  let fixture: ComponentFixture<TokengenTitleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TokengenTitleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TokengenTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
