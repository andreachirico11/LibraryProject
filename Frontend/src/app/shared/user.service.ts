import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from './models/userModel';

@Injectable({providedIn: 'root'})

export class UserService {
  loggedUser = new BehaviorSubject<User>(null);

  getLoggedUser() {
    this.loggedUser.next(
      JSON.parse(localStorage.getItem('loggedUser'))
    );
  }


}
