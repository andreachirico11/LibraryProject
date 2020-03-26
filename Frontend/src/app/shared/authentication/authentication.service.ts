import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, tap } from "rxjs/operators";
import { throwError, BehaviorSubject } from 'rxjs';
import { User } from './userModel';
import { Router } from '@angular/router';

@Injectable({ providedIn: "root" })

export class AuthenticationService {

  loggedUser = new BehaviorSubject<User>(null);

  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string) {
    return this.http
      .post("http://localhost:4200/authentication", {
        email: email,
        password: password
      })
      .pipe(
        catchError(this.handleError),
        tap( (resData: User) => {
          this.handleResponse(resData);
        })
      );
  }

  autoLogin() {
    const localStoredUser = JSON.parse( localStorage.getItem('loggedUser'));
    if(localStoredUser) {
      this.loggedUser.next(localStoredUser);
    }
  }

  handleError(res: HttpErrorResponse) {
    console.log(res);
    return throwError('errore')
  }

  handleResponse(res: User) {
    const newUser = new User(res.email, res.password, res.token, res.isAdmin);
    this.loggedUser.next(newUser);
    localStorage.setItem('loggedUser', JSON.stringify(newUser));
  }

  logout() {
    localStorage.clear();
    this.loggedUser.next(null);
    this.router.navigate(['']);
  }


}



