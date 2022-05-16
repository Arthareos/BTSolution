import {Component, Input} from '@angular/core';
import {UserService} from "../../services/user-service/user.service";

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.scss']
})
export class UserCardComponent {
  @Input("userId") id = 0;
  @Input("userName") name = "";

  constructor(private userService: UserService) {}

  deleteUser(): void {
    this.userService.removeUser(this.id);
  }
}
