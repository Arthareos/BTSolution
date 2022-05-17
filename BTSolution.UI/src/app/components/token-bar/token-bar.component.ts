import {Component, OnInit} from '@angular/core';
import {AccessToken} from "../../interfaces/access-token";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {TokenService} from "../../services/token-service/token.service";

@Component({
  selector: 'app-token-bar',
  templateUrl: './token-bar.component.html',
  styleUrls: ['./token-bar.component.scss']
})
export class TokenBarComponent implements OnInit {
  public accessTokens: Array<AccessToken> = [];
  public isShowingAccessTokens: boolean = false;

  public userId: number = 0;
  public durationInSeconds: number = 0;

  constructor(private accessTokenService: TokenService, private modalService: NgbModal) {}

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
    this.accessTokenService.getAllValidAccessTokens().subscribe({
      next: (v) => this.accessTokens = v,
      error: (e) => console.log(e),
      complete: () => {}
    });
  }

  generateAccessToken(): void {
    this.accessTokenService.generateAccessToken(this.userId, this.durationInSeconds);

    setTimeout(() => { this.getAllValidAccessTokens(); }, 1000);
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
