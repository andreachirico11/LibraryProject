import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { User } from "./models/userModel";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { take } from "rxjs/operators";
import { Router } from "@angular/router";
import { environment } from "../../environments/environment";


@Injectable({ providedIn: "root" })
export class UserService {
  private connString = environment.connectionStr + "users";
  public loggedUserLocal: User;
  public loggedUser = new BehaviorSubject<User>(null);
  private mockConnStr = "http://localhost:4200/postUserMock";
  private head = new HttpHeaders({ "Content-Type": "application/json" });

  constructor(private http: HttpClient, private router: Router) {}

  getLoggedUser() {
    this.loggedUser.next(JSON.parse(localStorage.getItem("loggedUser")));
  }

  getAllUsers() {
    return this.http.get<User[]>(this.connString);
  }

  refreshUser() {
    const id = this.loggedUserLocal.idUser;
    this.http
      .get(this.connString + "/" + id)
      .pipe(take(1))
      .subscribe((res: User) => {
        this.setUser(res);
      });
  }

  sendNewUser(newUser: User): BehaviorSubject<boolean> {
    let callResult = new BehaviorSubject<boolean>(false);
    const jsonUser = JSON.stringify(newUser);
    this.http
      .post(this.connString, jsonUser, { headers: this.head })
      .pipe(take(1))
      .subscribe(
        (res: string) => {
          if (res) {
            this.loggedUserLocal = JSON.parse( JSON.stringify(res));
            localStorage.setItem("loggedUser", JSON.stringify(res));
            this.loggedUser.next(this.loggedUserLocal);
            callResult.next(true);
            this.router.navigate(["/home"]);
          } else {
            alert("AlreadyRegistered")
            // return callResult;
          }
        },
        error => console.error("sendNewUserError")
      );
    return callResult;
  }

  setUser(returnedLoggedUser: User) {
    this.loggedUserLocal = returnedLoggedUser;
    this.loggedUser.next(this.loggedUserLocal);
    localStorage.setItem("loggedUser", JSON.stringify(returnedLoggedUser));
  }

  clearUser() {
    localStorage.clear();
    this.loggedUserLocal = null;
    this.loggedUser.next(null);
    this.router.navigate([""]);
  }

  addorRemoveBookFromFavourites(addOrRemove: boolean, idBook, idUser) {
    const connStr =
      environment.connectionStr + "userFavourites/" + (addOrRemove
        ? "add"
        : "remove");
    this.http
      .post(connStr, { idBook: idBook, idUser: idUser })
      .pipe(take(1)).subscribe(() => this.refreshUser());
  }
}
