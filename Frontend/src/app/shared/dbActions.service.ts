import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { BookModel } from "./bookModel";
import { map } from "rxjs/operators";


@Injectable({ providedIn: "root" })
export class dbService {
  constructor(private http: HttpClient) {}
  // ################SAMPLE http://covers.openlibrary.org/b/isbn/9780385472579-S.jpg
  private head = new HttpHeaders({ "Content-Type": "application/json" });

  getAllBooks() {
    return this.http.get<BookModel[]>(environment.connectionStr + "books").pipe(
      map( books => {
        books.forEach( b => {
          b.imagePath = `http://covers.openlibrary.org/b/isbn/${b.isbn}-M.jpg`;
        })
        return books
      }));
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
