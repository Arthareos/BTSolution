import { TokenService } from '../token-service/token.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { User } from "../../interfaces/user";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private _refreshNeeded$ = new Subject<void>();
  constructor(private http: HttpClient, private tokenService: TokenService) {}

  get refreshNeeded$() {
    return this._refreshNeeded$;
  }

  addUser(user: User): void {
    this.http
      .post<User[]>(`${environment.apiUrl}/User/AddUser`, user)
      .pipe(
        tap(() => {
          this._refreshNeeded$.next();
        })
      ).subscribe();
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/User/GetAllUsers`);
  }

  getUser(userId: number): Observable<User> {
    return this.http.get<User>(`${environment.apiUrl}/User/GetUser/${userId.toString()}`);
  }

  removeUser(userId: number): void {
    this.http
      .delete(`${environment.apiUrl}/User/RemoveUser/${userId}`)
      .subscribe({
        error: error => {
          console.log(`Error: ${error}`);
        },
        complete: () => {
          this._refreshNeeded$.next();
          this.tokenService.refreshNeeded$.next();
        }
      });
  }

  updateUser(user: User): void {
    this.http
      .put(`${environment.apiUrl}/User/UpdateUser`, user)
      .subscribe({
        error: error => {
          console.log(`Error: ${error}`);
        },
        complete: () => {
          this._refreshNeeded$.next();
          this.tokenService.refreshNeeded$.next();
        }
      });
  }
}
