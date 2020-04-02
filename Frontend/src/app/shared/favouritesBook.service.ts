import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap, take } from 'rxjs/operators';
import { UserService } from './user.service';
import { environment } from "../../environments/environment";


@Injectable({providedIn: 'root'})

export class FavouriteBookService {

  private connString = environment.connectionStr + "favourites";
  constructor(private http : HttpClient, private userService: UserService) {}


}
