import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'

@Injectable({providedIn: 'root'})

export class dbService {
  constructor(private http: HttpClient) {}

  getAllBooks() {
    this.http.get(environment.connectionStr + 'api/books').subscribe( r => console.log(r));
  }
}
