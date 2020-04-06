import { Component, Input, OnInit, OnDestroy } from "@angular/core";
import { User } from "src/app/shared/models/userModel";
import { Subscription } from "rxjs";
import { UserService } from "src/app/shared/user.service";
import { BorrowService } from "src/app/shared/borrow.service";
import { Loan } from "src/app/shared/models/loanModel";

@Component({
  selector: "app-user-borrowed",
  templateUrl: "./userBorrowed.component.html",
})
export class UserBorrowedComponent implements OnInit, OnDestroy {
  loggedUser: User = null;
  subscription: Subscription;
  subscription2: Subscription;
  public loans: Loan[] = [];

  constructor(
    private userService: UserService,
    private borrowService: BorrowService
  ) {}

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.subscription2.unsubscribe();
  }

  ngOnInit() {
    this.userService.getLoggedUser();
    this.subscription = this.userService.loggedUser.subscribe((logged) => {
      this.loggedUser = logged;
      this.getAllLoans();
    });
  }

  getAllLoans() {
    this.subscription2 = this.borrowService
    .getAllLoanedBooksByUserId(this.loggedUser.idUser)
    .subscribe((res: Loan[]) => this.loans = res);
  }

  returnBook(idBook: number) {
    this.borrowService.returnBook(idBook).subscribe( r => this.getAllLoans() );
  }
}
