import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpResponse
} from "@angular/common/http";
import { of } from "rxjs";
import { MockDBService } from './mockDB.service';
import { User } from '../models/userModel';

@Injectable({ providedIn: "root" })
export class MockCreateUserService implements HttpInterceptor {
  rb: string;
  isUserFound: boolean = false;

  constructor(private mockDb: MockDBService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    if (
      request.method === "POST" &&
      request.url === "http://localhost:4200/postUserMock"
    ) {
      this.rb = JSON.stringify(request.body);
      this.isUserFound = this.searchCorrespondantUser(this.rb);

      if(this.isUserFound) {
        return of(new HttpResponse({ status: 200, body: null }));
      } else {
        this.mockDb.addUser(request.body);
        return of(new HttpResponse({ status: 200, body: request.body }));
      }

    }
    return next.handle(request);
  }


 // rifare sto metodo di corrispondenza


  searchCorrespondantUser(respJsonUser: string): boolean {
    let foundUser = false;
    this.mockDb.userDB.forEach(u => {
      const jsonUser = JSON.stringify(u);
      if (respJsonUser === jsonUser) {
        foundUser = foundUser = true;
      }
    });
    return foundUser;
  }

}
