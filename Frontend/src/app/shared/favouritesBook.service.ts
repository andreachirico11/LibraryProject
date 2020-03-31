import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { UserService } from './user.service';

@Injectable({providedIn: 'root'})

export class FavouriteBookService {

  connectionString = "http://localhost:4200/addToFavMock";
  constructor(private http : HttpClient, private userService: UserService) {}

  addToFavourite(bookId: string) {
    return this.http.post(this.connectionString, bookId)
    .pipe(
      tap( resp => {
        if(resp === true) {
          this.userService.refreshUser();
        }
      })
    );
  }
}
