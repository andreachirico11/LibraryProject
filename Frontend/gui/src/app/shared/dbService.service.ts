import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({providedIn: 'root'})

export class dbService {
  constructor(private http: HttpClient) {}

  getAllBooks() {
    this.http.get('https://localhost:5001/api/books').subscribe( r => console.log(r))
  }
}
