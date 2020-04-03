import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { take, map } from "rxjs/operators";
import { UserService } from "./user.service";
import { loan } from "./models/loanModel";

@Injectable({ providedIn: "root" })
export class BorrowService {
  private connectionString = environment.connectionStr + "borrow";
  private maxBorrowDaysInMilliseconds = 31 * (1000 * 3600 * 24);

  constructor(
    private http: HttpClient,
    private userService: UserService
  ) {}

  borrowBook(idBook: number) {
    const idUser = this.userService.loggedUserLocal.idUser;
    return this.http
      .post(this.connectionString, { idBook: idBook, idUser: idUser })
      .pipe(take(1));
  }

  getAllLoanedBooksByUserId(idUser: number) {
    return this.http
      .get<loan[]>(this.connectionString + "/" + idUser)
      .pipe(
        map( res => this.addDaysLeft(res))
      );
  }

  calculateDaysLeft(dateOfBorrow: Date) {
    var dt = new Date(dateOfBorrow);
    const borrow = dt.getTime();
    const returnDate = borrow + this.maxBorrowDaysInMilliseconds;
    let now = Date.now();
    return Math.floor((returnDate - now) / (1000 * 3600 * 24));
  }

  addDaysLeft(loansToMap: loan[]) {
    loansToMap.forEach(loan => {
        loan.daysLeft = this.calculateDaysLeft(loan.dateStart);
    });
    return loansToMap;
  }

  returnBook(idBook: number) {
    return this.http.delete(this.connectionString + "/" + idBook).pipe(take(1));
  }
}
