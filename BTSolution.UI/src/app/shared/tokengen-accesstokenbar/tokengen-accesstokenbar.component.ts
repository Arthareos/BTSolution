import { AccessToken } from './../../services/interfaces/accessToken';
import { TokengenTokenService } from './../../services/tokengen-token.service';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-tokengen-accesstokenbar',
  templateUrl: './tokengen-accesstokenbar.component.html',
  styleUrls: ['./tokengen-accesstokenbar.component.scss']
})
export class TokengenAccesstokenbarComponent implements OnInit {
  public accessTokens: Array<AccessToken> = [];
  public isShowingAccessTokens: boolean = false;

  public userId: number = 0;
  public durationInSeconds: number = 0;

  constructor(private accessTokenService: TokengenTokenService, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.accessTokenService.refreshNeeded$.subscribe(() => this.getAllValidAccessTokens())
    this.getAllValidAccessTokens();
  }

  showAccessTokens(): void {
    this.isShowingAccessTokens = true;
  }

  hideAccessTokens(): void {
    this.isShowingAccessTokens = false;
  }

  getAllValidAccessTokens(): void {
    this.accessTokens = [];

    this.accessTokenService.getAllValidAccessTokens().subscribe({
      next: (v) => this.accessTokens = v,
      error: (e) => console.log(e),
      complete: () => {}
    });
  }

  generateAccessToken(): void {
    this.accessTokenService.generateAccessToken(this.userId, this.durationInSeconds);
  }

  getUserId(userId: string): void {
    this.userId = +userId;
  }

  getDuration(durationInSeconds: string): void {
    this.durationInSeconds = +durationInSeconds;
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-title'}).result;
  }
}
