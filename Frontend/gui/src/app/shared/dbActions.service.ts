import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { BookModel } from "./bookModel";
import * as mocks from "./mocks";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class dbService {
  constructor(private http: HttpClient) {}

  private head = new HttpHeaders({ "Content-Type": "application/json" });

  getAllBooks() {
    return this.http.get<BookModel[]>(environment.connectionStr + "books");
  }

  getBookById(id: number) {
    return this.http.get<BookModel>(environment.connectionStr + "books/" + id);
  }

  postBook(newBook: BookModel) {
    var jsonBook = JSON.stringify(newBook);
    return this.http.post(environment.connectionStr + "books", jsonBook, {
      headers: this.head
    });
  }

  putBook(modifiedBook: BookModel, id: number) {
    var jsonBook = JSON.stringify(modifiedBook);
    return this.http.put(
      environment.connectionStr + "books/" + id,
      jsonBook,
      { headers: this.head }
    );
  }

  deleteBookById(id: number) {
    return this.http.delete(environment.connectionStr + "books/" + id);
  };
}
