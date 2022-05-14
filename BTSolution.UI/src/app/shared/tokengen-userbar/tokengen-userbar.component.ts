import { TokengenUserService } from './../../services/tokengen-user.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/services/interfaces/user';

@Component({
  selector: 'app-tokengen-userbar',
  templateUrl: './tokengen-userbar.component.html',
  styleUrls: ['./tokengen-userbar.component.scss']
})
export class TokengenUserbarComponent implements OnInit {
  public users: Array<User> = [];
  public isShowingUsers: boolean = false;

  constructor(private userService: TokengenUserService) { }

  ngOnInit(): void {
    this.userService.refreshNeeded$.subscribe(() => this.getAllUsers())
    this.getAllUsers();
  }

  showUsers(): void {
    this.isShowingUsers = true;
  }

  hideUsers(): void {
    this.isShowingUsers = false;
  }

  getAllUsers(): void {
    this.userService.getAllUsers().subscribe({
      next: (v) => this.users = v,
      error: (e) => console.log(e),
      complete: () => {}
    });
  }

}
