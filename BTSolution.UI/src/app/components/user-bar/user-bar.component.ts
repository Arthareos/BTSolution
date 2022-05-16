import {Component, OnInit} from '@angular/core';
import {UserService} from "../../services/user-service/user.service";
import {User} from "../../interfaces/user";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-user-bar',
  templateUrl: './user-bar.component.html',
  styleUrls: ['./user-bar.component.scss']
})
export class UserBarComponent implements OnInit {
  public users: Array<User> = [];
  public isShowingUsers: boolean = false;

  public userName: string = "";

  constructor(private userService: UserService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.userService.refreshNeeded$.subscribe(() => this.getAllUsers())
    this.getAllUsers();

    if (this.users.length == 0) {
      this.isShowingUsers = false;
    }
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
      complete: () => {
        if (this.users.length == 0) {
          this.isShowingUsers = false;
        }
      }
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
