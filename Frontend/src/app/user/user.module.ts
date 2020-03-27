import { NgModule } from '@angular/core';
import { RouterModule, Routes } from'@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { UserBorrowedComponent } from './userBorrowedBooks/userBorrowed.component';
import { UserInfoComponent } from './userInfo/userInfo.component';
import { UserImgComponent } from './userImg/userImg.component';
import { UserFavouritesComponent } from './userFavourites/userFavourites.component';

const routes: Routes = [
  {path: 'user', component: UserComponent, children: [
    {path: 'favourites', component: UserFavouritesComponent},
    {path: 'borrowed', component: UserBorrowedComponent},
    {path: 'info', component: UserInfoComponent}
  ]},


];

@NgModule({
  declarations: [
    UserComponent,
    UserBorrowedComponent,
    UserInfoComponent,
    UserImgComponent,
    UserFavouritesComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    FontAwesomeModule,
    CommonModule
  ]
})

export class UserModule {}
