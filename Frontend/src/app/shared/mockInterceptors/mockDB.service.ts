import { Injectable } from '@angular/core';
import { User } from '../models/userModel';
import { Users } from '../models/mocks';

@Injectable({providedIn: 'root'})

export class MockDBService{
  public userDB: User[] = [...Users];

  addUser(newUser: User) {
    this.userDB = [...this.userDB, newUser ];
  }


}
