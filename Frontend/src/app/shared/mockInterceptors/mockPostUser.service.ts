import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpResponse
} from "@angular/common/http";
import { of } from "rxjs";
import { MockDBService } from "./mockDB.service";
import { User } from "../models/userModel";

@Injectable({ providedIn: "root" })
export class MockCreateUserService implements HttpInterceptor {
  isUserFound: boolean = false;
  userInReqBody: User;

  constructor(private mockDb: MockDBService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    if (
      request.method === "POST" &&
      request.url === "http://localhost:4200/postUserMock"
    ) {

      this.userInReqBody = request.body;
      this.isUserFound = this.searchCorrespondantUser(this.userInReqBody);

      if (this.isUserFound) {
        return of(new HttpResponse({ status: 200, body: null }));
      } else {
        this.mockDb.addUser(this.userInReqBody);
        return of(new HttpResponse({ status: 200, body: this.userInReqBody }));
      }
    }
    return next.handle(request);
  }



  searchCorrespondantUser(userToFind: User): boolean {
    let foundUser = false;
    this.mockDb.userDB.forEach(u => {
      if (
        userToFind.surname === u.surname &&
        userToFind.name === u.name
      ) {
        foundUser = true;
      }
      if(userToFind.email === u.email) {
        foundUser = true;
      }
    });
    return foundUser;
  }
}
