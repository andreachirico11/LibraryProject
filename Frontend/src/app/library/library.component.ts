import { Component, OnInit, OnDestroy } from "@angular/core";
import { dbService } from "../shared/books.service";
import { BookModel } from "../shared/models/bookModel";
import { Subscription } from "rxjs";
import { faBook } from "@fortawesome/free-solid-svg-icons";
import { FavouriteBookService } from "../shared/favouritesBook.service";
import { UserService } from "../shared/user.service";
import { User } from "../shared/models/userModel";

@Component({
  selector: "app-library",
  templateUrl: "./library.component.html"
})
export class LibraryComponent implements OnInit, OnDestroy {
  bookIcon = faBook;

  public libraryDb: BookModel[] = [];
  private dbSubs: Subscription;
  private userSub: Subscription;
  private userLogged: User;

  constructor(
    private dbservice: dbService,
    private favBookService: FavouriteBookService,
    private userService: UserService
  ) {}

  ngOnDestroy() {
    this.userSub.unsubscribe();
    this.dbSubs.unsubscribe();
  }

  ngOnInit() {
    this.getAllBooks();
    this.userSub = this.userService.loggedUser.subscribe(u => this.getAllBooks());
  }

  getAllBooks() {
    this.dbSubs = this.dbservice
    .getAllBooks()
    .subscribe((books: BookModel[]) => {
      this.libraryDb = books;
    });
  }
}
