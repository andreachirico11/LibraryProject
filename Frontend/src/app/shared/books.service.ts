import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { BookModel } from "./models/bookModel";
import { map, take, filter } from "rxjs/operators";
import { UserService } from "./user.service";

@Injectable({ providedIn: "root" })
export class dbService {
  constructor(private http: HttpClient, private userService: UserService) {}
  private head = new HttpHeaders({ "Content-Type": "application/json" });

  getAllBooks() {
    return this.http.get<BookModel[]>(environment.connectionStr + "books").pipe(
      map(books => {
        return this.addCover(books);
      }),
      map((books: BookModel[]) => {
        if (this.userService.loggedUserLocal) {
          this.addIfIsFav(books);
        }
        return books;
      })
    );
  }


  getBookById(id: number) {
    return this.http.get<BookModel>(environment.connectionStr + "books/" + id);
  }

  getAllBooksWithoutCover() {
    return this.http.get<BookModel[]>(environment.connectionStr + "books");
  }


  addCover(books: BookModel[]): BookModel[] {
    books.forEach(b => {
      // b.imagePath = `http://covers.openlibrary.org/b/isbn/${b.isbn}-M.jpg`;
      this.http
      .get(`https://www.googleapis.com/books/v1/volumes?q=isbn:${b.isbn}`)
      .pipe(take(1))
      .subscribe(r => {
        const resp = JSON.parse(JSON.stringify(r));
        b.imagePath = resp.items[0].volumeInfo.imageLinks.thumbnail;
        });
    });
    return books;
  }

  addIfIsFav(books: BookModel[]) {
    return books.forEach(book => {
      this.isFavourite(book);
    });
  }

  isFavourite(book: BookModel) {
    const isFav = this.userService.loggedUserLocal.favourites.find(
      favBook => book.idBook == favBook.idBook
      );
      if (isFav) {
        book.isFav = true;
      } else {
        book.isFav = false;
      }
      return book;
    }







  }

















  // postBook(newBook: BookModel) {
  //   var jsonBook = JSON.stringify(newBook);
  //   return this.http.post(environment.connectionStr + "books", jsonBook, {
  //     headers: this.head
  //   });
  // }

  // putBook(modifiedBook: BookModel, id: number) {
  //   var jsonBook = JSON.stringify(modifiedBook);
  //   return this.http.put(environment.connectionStr + "books/" + id, jsonBook, {
  //     headers: this.head
  //   });
  // }

  // deleteBookById(id: number) {
  //   return this.http.delete(environment.connectionStr + "books/" + id);
  // }
