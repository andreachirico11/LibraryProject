import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from './models/userModel';
import {  HttpClient, HttpHeaders } from '@angular/common/http';
import { take } from 'rxjs/operators';

@Injectable({providedIn: 'root'})

export class UserService {
  loggedUser = new BehaviorSubject<User>(null);
  private mockConnStr = "http://localhost:4200/postUserMock";
  private head = new HttpHeaders({ "Content-Type": "application/json" });

  constructor(private http: HttpClient) {}


  getLoggedUser() {
    this.loggedUser.next(
      JSON.parse(localStorage.getItem('loggedUser'))
    );
  }

  sendNewUser(newUser: User) {
    const jsonUser = JSON.stringify(newUser);
    this.http.post(this.mockConnStr, jsonUser, {headers: this.head})
    .pipe(take(1))
    .subscribe(
      res => console.log(res)
    )
  }


}
