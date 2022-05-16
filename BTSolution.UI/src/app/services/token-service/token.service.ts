import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { AccessToken } from "../../interfaces/access-token";

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private _refreshNeeded$ = new Subject<void>();
  constructor(private http: HttpClient) {}

  get refreshNeeded$() {
    return this._refreshNeeded$;
  }

  generateAccessToken(userId: number, durationInSeconds: number): void {
    this.http
      .post(`${environment.apiUrl}/AccessToken/GenerateAccessToken/${userId}/${durationInSeconds}`, null)
      .pipe(
        tap(() => {
          this._refreshNeeded$.next();
        })
      ).subscribe();
  }

  getAllAccessTokens(): Observable<AccessToken[]> {
    return this.http.get<AccessToken[]>(`${environment.apiUrl}/AccessToken/GetAllAccessTokens/`);
  }

  getAllUserAccessTokens(userId: number): Observable<AccessToken[]> {
    return this.http.get<AccessToken[]>(`${environment.apiUrl}/AccessToken/GetAllUserAccessTokens/${userId}`);
  }

  getAllValidAccessTokens(): Observable<AccessToken[]> {
    return this.http.get<AccessToken[]>(`${environment.apiUrl}/AccessToken/GetValidAccessTokens/`);
  }

  getAllValidUserAccessTokens(userId: number): Observable<AccessToken[]> {
    return this.http.get<AccessToken[]>(`${environment.apiUrl}/AccessToken/GetValidUserAccessTokens/${userId}`);
  }
}
