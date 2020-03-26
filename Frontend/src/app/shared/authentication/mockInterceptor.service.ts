import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import {  of } from 'rxjs';
import { User } from './userModel';

Injectable({providedIn: 'root'})

export class MockInterceptorService implements HttpInterceptor{
  rb: string;
  usResp: string;
  correspondantUser: User = null;
  index: number = -1;

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    if(request.method === 'POST' && request.url ==="http://localhost:4200/authentication") {
    this.rb =  JSON.stringify (request.body );

    Users.forEach( u => {
      this.index++;
      this.usResp = JSON.stringify( { email: u.email, password: u.password })
      if(this.usResp === this.rb) {
        this.correspondantUser = Users[this.index];
      }
       else {
       return of(new HttpResponse({status: 404, statusText: 'WRONG CREDENTIALS'}));
      }
    });
  }
  if(this.correspondantUser) {
    return  of(new HttpResponse({status: 200, body: this.correspondantUser}));
    }
    return next.handle(request);
  }
}



const Users =
[
   new User('giuseppe@email.it', 'giuseppe123', 'abcdefg', false),
   new User('carlo@email.it', 'carlo123', 'gklmno', true)
]
