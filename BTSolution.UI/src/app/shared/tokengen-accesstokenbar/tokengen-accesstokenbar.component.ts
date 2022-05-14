import { AccessToken } from './../../services/interfaces/accessToken';
import { TokengenTokenService } from './../../services/tokengen-token.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tokengen-accesstokenbar',
  templateUrl: './tokengen-accesstokenbar.component.html',
  styleUrls: ['./tokengen-accesstokenbar.component.scss']
})
export class TokengenAccesstokenbarComponent implements OnInit {
  public accessTokens: Array<AccessToken> = [];

  constructor(private accessTokenService: TokengenTokenService) { }

  ngOnInit(): void {
    this.getAllValidAccessTokens();
  }

  getAllValidAccessTokens(): void {
    this.accessTokens = [];

    this.accessTokenService.getAllValidAccessTokens().subscribe({
      next: (v) => this.accessTokens = v,
      error: (e) => console.log(e),
      complete: () => {}
    });
  }

}
