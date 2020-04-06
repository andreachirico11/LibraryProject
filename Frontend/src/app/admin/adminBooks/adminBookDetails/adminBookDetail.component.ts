import { Component, Input } from '@angular/core';
import { BookModel } from 'src/app/shared/models/bookModel';

@Component({
  selector: "app-admin-book-detail",
  templateUrl: "./adminBookDetail.component.html"
})

export class AdminBooksDetailComponent {

  @Input() bookToShow : BookModel;
}
