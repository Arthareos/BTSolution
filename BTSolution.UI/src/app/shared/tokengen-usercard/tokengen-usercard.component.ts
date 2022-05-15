import { TokengenUserbarComponent } from './../tokengen-userbar/tokengen-userbar.component';
import { Component, Input } from '@angular/core';
import { TokengenUserService } from 'src/app/services/tokengen-user.service';

@Component({
  selector: 'app-tokengen-usercard',
  templateUrl: './tokengen-usercard.component.html',
  styleUrls: ['./tokengen-usercard.component.scss']
})
export class TokengenUsercardComponent {
  @Input("userId") id = 0;
  @Input("userName") name = "";

  constructor(private userService: TokengenUserService) {}

  deleteUser(): void {
    this.userService.removeUser(this.id);
  }
}
