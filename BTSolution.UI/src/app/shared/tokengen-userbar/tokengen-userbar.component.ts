import { TokengenUserService } from './../../services/tokengen-user.service';
import { Component, ElementRef, OnInit } from '@angular/core';
import { User } from 'src/app/services/interfaces/user';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-tokengen-userbar',
  templateUrl: './tokengen-userbar.component.html',
  styleUrls: ['./tokengen-userbar.component.scss']
})
export class TokengenUserbarComponent implements OnInit {
  public users: Array<User> = [];
  public isShowingUsers: boolean = false;

  public userName: string = "";

  constructor(private userService: TokengenUserService, private modalService: NgbModal) { }

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

  addUser(): void {
    var newUser: User = {userId: 0, userName: this.userName};
    this.userService.addUser(newUser);
  }

  getUserName(name: string): void {
    this.userName = name;
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-title'}).result;
  }
}
