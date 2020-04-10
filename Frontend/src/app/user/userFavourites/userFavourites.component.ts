import { Component, OnInit, OnDestroy } from "@angular/core";
import { User } from "src/app/shared/models/userModel";
import { Subscription } from "rxjs";
import { UserService } from "src/app/shared/user.service";
import { dbService } from "src/app/shared/books.service";
import { BookModel } from "src/app/shared/models/bookModel";
import { take } from "rxjs/operators";

@Component({
  selector: "app-user-favourites",
  templateUrl: "./userFavourites.component.html",
})
export class UserFavouritesComponent implements OnInit, OnDestroy {
  loggedUser: User = null;
  subscription: Subscription;
  favouriteBooks: BookModel[];

  constructor(
    private userService: UserService,
    private bookService: dbService
  ) {}

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  ngOnInit() {
    this.userService.getLoggedUser();
    this.subscription = this.userService.loggedUser.subscribe((logged) => {
      this.loggedUser = logged;
      if (this.loggedUser && this.loggedUser.favourites) {
        this.loggedUser.favourites = this.bookService.addCover(
          this.loggedUser.favourites
        );
      }
    });
  }
}
