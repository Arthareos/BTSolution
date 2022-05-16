import {Component, Input, OnInit} from '@angular/core';
import {TokenService} from "../../services/token-service/token.service";

@Component({
  selector: 'app-token-card',
  templateUrl: './token-card.component.html',
  styleUrls: ['./token-card.component.scss']
})
export class TokenCardComponent implements OnInit {
  @Input("accessTokenId") accessTokenId: number = 0;
  @Input("expiryDate") expiryDate: number = 0;
  @Input("token") token: string = "";
  @Input("userId") userId: number = 0;
  @Input("userName") userName: string = "";

  public timeLeft: number = 0;
  private countdownInterval: any;

  constructor(private tokenService: TokenService) {}

  ngOnInit(): void {
    this.countdownInterval = setInterval(() => {
      this.timeLeft = this.expiryDate - Math.floor(Date.now() / 1000);

      if (this.timeLeft <= 0) {
        this.tokenService.refreshNeeded$.next();
        clearInterval(this.countdownInterval);
      }
    }, 1000);
  }
}
