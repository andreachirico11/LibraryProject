import { Component, OnInit, Output } from '@angular/core';
import { BookModel } from 'src/app/shared/models/bookModel';
import { AdminService } from '../admin.service';

@Component({
  selector: "app-admin-books",
  templateUrl: "./adminBooks.component.html"
})

export class AdminBooksComponent implements OnInit {
  allBooks: BookModel[] = [];
  @Output() bookToEmit: BookModel;
  public detailActivated = false;
  constructor(private adminService: AdminService) {}

  ngOnInit() {
    this.adminService.allBooks.subscribe(
      books => this.allBooks = [...books]
    );
    this.adminService.getAllBooks().subscribe();
  }

  openDetails(bookId: number) {
    this.detailActivated === false ? this.detailActivated = true : null;

    const foundIndex = this.allBooks.findIndex(
      book => book.idBook === bookId
    );
    this.bookToEmit = this.allBooks[foundIndex];
  }
}
