import { Injectable } from '@angular/core';
import { UserService } from '../shared/user.service';
import { dbService } from '../shared/books.service';
import { BorrowService } from '../shared/borrow.service';
import { User } from '../shared/models/userModel';
import { BookModel } from '../shared/models/bookModel';
import { Loan } from '../shared/models/loanModel';
import { tap } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Injectable()

export class AdminService {

  constructor(
    private userService: UserService,
    private booksService: dbService,
    private loansService: BorrowService
  ) {}



  allUsers = new BehaviorSubject<User[]>([]);
  allBooks = new BehaviorSubject<BookModel[]>([]);
  allLoans = new BehaviorSubject<Loan []>([]);


  getAllBooks() {
    return this.booksService.getAllBooksWithoutCover().pipe(
      tap( (res: BookModel[]) => this.allBooks.next(res))
    );
  }
  getAllUsers() {
    return this.userService.getAllUsers().pipe(
      tap( (res: User[]) => this.allUsers.next(res))
    );
  }
  getAllLoans() {
    return this.loansService.getAllLoans().pipe(
      tap( (res: Loan[]) => this.allLoans.next(res))
    );
  }
}
