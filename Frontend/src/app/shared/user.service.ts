import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { User } from "./models/userModel";
import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { take } from "rxjs/operators";
import { Router } from "@angular/router";
import { AuthenticationService } from "./authentication.service";

@Injectable({ providedIn: "root" })
export class UserService {
  private loggedUserLocal : User
  loggedUser = new BehaviorSubject<User>(null);
  private mockConnStr = "http://localhost:4200/postUserMock";
  private head = new HttpHeaders({ "Content-Type": "application/json" });

  constructor(
    private http: HttpClient,
    private router: Router,
    private authService: AuthenticationService
  ) {}

  getLoggedUser() {
    this.loggedUser.next(JSON.parse(localStorage.getItem("loggedUser")));
  }

  refreshUser() {
    const id = this.loggedUserLocal.idUser;
    this.http
      .get(this.mockConnStr, )
      .pipe(take(1))
      .subscribe((res: string) => {
        localStorage.setItem("loggedUser", res);
        this.authService.loggedUser.next(JSON.parse(res));
      });
  }

  sendNewUser(newUser: User): BehaviorSubject<boolean> {
    let callResult = new BehaviorSubject<boolean>(false);
    const jsonUser = JSON.stringify(newUser);
    this.http
      .post(this.mockConnStr, jsonUser, { headers: this.head })
      .pipe(take(1))
      .subscribe(
        (res: string) => {
          if (res) {
            localStorage.setItem("loggedUser", res);
            this.loggedUserLocal = JSON.parse(res);
            this.authService.loggedUser.next(this.loggedUserLocal);
            callResult.next(true);
          }
          this.router.navigate(["/home"]);
          return callResult;
        },
        error => console.log("sendNewUserError")
      );
    return callResult;
  }
}
