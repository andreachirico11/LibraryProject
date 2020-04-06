import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminGuard } from './admin.guard.service';
import { AdminNavbarComponent } from './adminNavbar/adminNavbar.component';
import { AdminService } from './admin.service';
import { AdminUsersComponent } from './adminUsers/adminUsers.component';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AdminUserDetailComponent } from './adminUsers/adminUserDetail/adminUserDetail.component';
import { AdminBooksComponent } from './adminBooks/adminBooks.component';
import { AdminBooksDetailComponent } from './adminBooks/adminBookDetails/adminBookDetail.component';
import { AdminLoansComponent } from './adminLoans/adminLoans.component';

const routes : Routes = [
  {path: "admin", component: AdminComponent, canActivate: [AdminGuard], children: [
    {path: "users", component: AdminUsersComponent},
    {path: "books", component: AdminBooksComponent},
    {path: "loans", component: AdminLoansComponent }
  ]}
];

@NgModule({
  declarations: [
    AdminComponent,
    AdminNavbarComponent,
    AdminUsersComponent,
    AdminUserDetailComponent,
    AdminBooksComponent,
    AdminBooksDetailComponent,
    AdminLoansComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    BrowserModule
  ],
  providers: [
    AdminGuard,
    AdminService
  ]
})

export class AdminModule {}
