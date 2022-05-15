import { TokengenTokenService } from './../../services/tokengen-token.service';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-tokengen-accesstokencard',
  templateUrl: './tokengen-accesstokencard.component.html',
  styleUrls: ['./tokengen-accesstokencard.component.scss']
})
export class TokengenAccesstokencardComponent {
  @Input("accessTokenId") accessTokenId: number = 0;
  @Input("expiryDate") expiryDate: number = 0;
  @Input("token") token: string = "";
  @Input("userId") userId: number = 0;
  @Input("userName") userName: string = "";

  public timeLeft: number = 0;
  private countdownInterval: any;

  constructor(private tokenService: TokengenTokenService) {}

  ngOnInit(): void {
    this.countdownInterval = setInterval(() => {
      this.timeLeft = this.expiryDate - Math.floor(Date.now() / 1000);

      if (this.timeLeft <= 0) {
        this.tokenService.refreshNeeded$.next();
        clearInterval(this.countdownInterval);
      }
    }, 1000);
  }

  ngOnDestroy(): void {
    clearInterval(this.countdownInterval);
  }
}
