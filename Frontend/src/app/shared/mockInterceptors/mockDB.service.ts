import { Injectable } from '@angular/core';
import { User } from '../models/userModel';
import { Users } from '../models/mocks';
import { BookModel } from '../models/bookModel';
import { dbService } from '../books.service';

@Injectable({providedIn: 'root'})

export class MockDBService{
  public userDB: User[] = [...Users];
  public bookDB: BookModel[];



  addUser(newUser: User) {
    this.userDB = [...this.userDB, newUser ];
  }

  // getAllBooks() {
  //    this.bookservice.getAllBooks().subscribe( b => this.bookDB = [...b]
  //    );
  // }

  // addBookToUserFav(idBook: number, idUser: number) {
  //   let success = false;
  //   this.bookDB.forEach(book => {
  //     if(book.idBook === idBook) {
  //       this.userDB.forEach(user => {
  //         if(user.idUser === idUser) {
  //           user.favourites.push(idBook);
  //           success = true;
  //         }
  //       })
  //     }
  //   });
  //   return success;
  // }

}
