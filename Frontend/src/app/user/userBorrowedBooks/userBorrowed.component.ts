import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { User } from 'src/app/shared/models/userModel';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-user-borrowed',
  templateUrl: './userBorrowed.component.html'
})

export class UserBorrowedComponent implements OnInit, OnDestroy {

  loggedUser: User = null;
  subscription: Subscription

  constructor(private userService: UserService) {}

  ngOnDestroy() { this.subscription.unsubscribe() }

  ngOnInit() {
    this.userService.getLoggedUser();
    this.subscription = this.userService.loggedUser.subscribe( logged => this.loggedUser = logged);
  }
}
