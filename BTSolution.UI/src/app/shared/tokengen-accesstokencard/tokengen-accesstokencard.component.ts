import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-tokengen-accesstokencard',
  templateUrl: './tokengen-accesstokencard.component.html',
  styleUrls: ['./tokengen-accesstokencard.component.scss']
})
export class TokengenAccesstokencardComponent {
  @Input("accessTokenId") accessTokenId = 0;
  @Input("expiryDate") expiryDate = "";
  @Input("token") token = "";
  @Input("userId") userId = 0;
  @Input("userName") userName = "";

  constructor() { }
}
