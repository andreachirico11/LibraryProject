import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { BehaviorSubject, throwError } from "rxjs";
import { User } from "./models/userModel";
import { Router } from "@angular/router";
import { environment } from "../../environments/environment";
import { catchError, tap } from 'rxjs/operators';

@Injectable({ providedIn: "root" })
export class AuthenticationService {
  loggedUser = new BehaviorSubject<User>(null);
  authUrl = "http://localhost:4200/authenticationMock";
  // authUrl = environment.connectionStr + "users/auth";

  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string) {
    return this.http
      .post(this.authUrl, {
        email: email,
        password: password
      })
      .pipe(
        catchError(this.handleError),
        tap((resData: User) => {
          this.handleResponse(resData);
        })
      );
  }

  autoLogin() {
    const localStoredUser = JSON.parse(localStorage.getItem("loggedUser"));
    if (localStoredUser) {
      this.loggedUser.next(localStoredUser);
    }
  }

  handleError(res: HttpErrorResponse) {
    console.error(res.message)
    alert("Wrong Usermail or Password")
    return throwError("errore");
  }

  handleResponse(res: User) {
    if(res == null) {
      return null;
    }
    const newUser = new User(
      res.email,
      res.password,
      res.token,
      res.isAdmin,
      res.name,
      res.surname,
      res.idUser,
      res.phone,
      res.address,
      res.imgPath,
      res.favourites,
      res.borrowed
    );
    this.loggedUser.next(newUser);
    localStorage.setItem("loggedUser", JSON.stringify(newUser));
  }

  logout() {
    localStorage.clear();
    this.loggedUser.next(null);
    this.router.navigate([""]);
  }
}
