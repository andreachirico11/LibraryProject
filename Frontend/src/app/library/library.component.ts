import { Component, OnInit, OnDestroy } from '@angular/core';
import { dbService } from '../shared/dbActions.service';
import { BookModel } from '../shared/bookModel';
import { Subscription } from 'rxjs';
import { faBook } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-library',
  templateUrl: './library.component.html'
})

export class LibraryComponent implements OnInit, OnDestroy {
  bookIcon = faBook;

  public libraryDb: BookModel[] = [];
  private dbSubs: Subscription;

  constructor(private dbservice : dbService) {}

  ngOnDestroy() {
    this.dbSubs.unsubscribe();
  }

  ngOnInit(){
    this.dbSubs = this.dbservice.getAllBooks().subscribe(
      (r: BookModel[]) => {
        console.log(r);
        this.libraryDb = [ ...this.libraryDb, ...r];
      }
    );
  }
}
