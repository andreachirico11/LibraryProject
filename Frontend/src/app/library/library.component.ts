import { Component, OnInit, OnDestroy } from "@angular/core";
import { dbService } from "../shared/books.service";
import { BookModel } from "../shared/models/bookModel";
import { Subscription } from "rxjs";
import { faBook } from "@fortawesome/free-solid-svg-icons";
import { BorrowService } from "../shared/borrow.service";
import { UserService } from "../shared/user.service";

@Component({
  selector: "app-library",
  templateUrl: "./library.component.html"
})
export class LibraryComponent implements OnInit, OnDestroy {
  bookIcon = faBook;

  public libraryDb: BookModel[] = [];
  private dbSubs: Subscription;
  private userSub: Subscription;
  public borrowEnabled: boolean;

  constructor(
    private dbservice: dbService,
    private borrowService: BorrowService,
    private userService: UserService
  ) {}

  ngOnDestroy() {
    this.userSub.unsubscribe();
    this.dbSubs.unsubscribe();
  }

  ngOnInit() {
    this.getAllBooks();
    this.userSub = this.userService.loggedUser.subscribe(u => {
      this.getAllBooks();
      if (this.userService.loggedUserLocal) {
        this.borrowEnabled = true;
      } else {
        this.borrowEnabled = false;
      }
    });
  }

  getAllBooks() {
    this.dbSubs = this.dbservice
      .getAllBooks()
      .subscribe((books: BookModel[]) => {
        this.libraryDb = books;
      });
  }

  addOrRemoveFromFavourite(addOrRemove: boolean, idBook: number) {
    const addOrRem = addOrRemove ? true : false;
    this.userService.addorRemoveBookFromFavourites(
      addOrRem,
      idBook,
      this.userService.loggedUserLocal.idUser
    );
  }

  borrowBook(idBook: number) {
    this.borrowService.borrowBook(idBook).subscribe(b => this.getAllBooks());
  }
}
