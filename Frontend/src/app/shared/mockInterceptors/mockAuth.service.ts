import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpResponse
} from "@angular/common/http";
import { of } from "rxjs";
import { User } from "../models/userModel";
import { MockDBService } from './mockDB.service';

@Injectable({ providedIn: "root" })

export class MockInterceptorService implements HttpInterceptor {
  rb: string;
  correspondantUser: User = null;
  index: number = -1;

  constructor( private mockDB: MockDBService) {}

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
    this.mockDB.userDB.forEach(u => {
      index++;
      const jsonUser = JSON.stringify({ email: u.email, password: u.password });
      if (jsonUser === jsonCredential) {
        foundUser = this.mockDB.userDB[index];
      }
    });
    return foundUser;
  }
}


