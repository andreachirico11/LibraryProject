import { Component, OnInit } from '@angular/core';
import { dbService } from './shared/dbService.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private serv : dbService) {}

  ngOnInit() {
    this.serv.getAllBooks();
  }
}
