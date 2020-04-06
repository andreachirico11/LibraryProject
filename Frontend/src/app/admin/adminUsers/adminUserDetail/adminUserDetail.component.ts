import { Component, Input, OnDestroy } from '@angular/core';
import { User } from 'src/app/shared/models/userModel';

@Component({
  selector: 'app-admin-user-detail',
  templateUrl: './adminUserDetail.component.html'
})

export class AdminUserDetailComponent  {

  @Input() userToShow : User;
}

