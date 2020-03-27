import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpResponse
} from "@angular/common/http";
import { of } from "rxjs";
import { User } from "../models/userModel";

Injectable({ providedIn: "root" });

export class MockInterceptorService implements HttpInterceptor {
  rb: string;
  usResp: string;
  correspondantUser: User = null;
  index: number = -1;

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    if ( request.method === "POST" && request.url === "http://localhost:4200/authenticationMock") {
      this.rb = JSON.stringify(request.body);
      this.correspondantUser = this.searchCorrespondantUser(this.rb);
    }

    if (this.correspondantUser) {
      return of(new HttpResponse({ status: 200, body: this.correspondantUser }));
    }
    return next.handle(request);
  }

  searchCorrespondantUser(jsonCredential: string): User {
    let index = -1;
    let foundUser = null;
    Users.forEach(u => {
      index++;
      const jsonUser = JSON.stringify({ email: u.email, password: u.password });
      if (jsonUser === jsonCredential) {
        foundUser = Users[index];
      }
    });
    return foundUser;
  }
}

const Users = [
  new User(
    1,
    "giuseppe@email.it",
    "giuseppe123",
    "abcdefg",
    false,
    "giuseppe",
    "giuseppi",
    3470000,
    "via giuseppe 123 genova",
    "https://source.unsplash.com/tD1XD54mx8w/600x600",
    [],
    []
  ),
  new User(
    2,
    "carlo@email.it",
    "carlo123",
    "gklmno",
    true,
    "carlo",
    "carli",
    34704582039,
    "via carlo 1 genova",
    "https://source.unsplash.com/_cvwXhGqG-o/600x600",
    [],
    []
  )
];
