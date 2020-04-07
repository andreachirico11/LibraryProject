import { NgModule } from '@angular/core';
import { NavbarComponent } from './navbar.component';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarLoginFormComponent } from './navbarLoginForm/navbarLoginForm.component';
import { RouterModule } from '@angular/router';
import { NavbarNavigationComponent } from './navbarNavigation/navbarNavigation.component';
import { NavbarLoggedComponent } from './navbarLoggedComponent/navbarLoggedComponent';
@NgModule({
  declarations: [
    NavbarComponent,
    NavbarLoginFormComponent,
    NavbarNavigationComponent,
    NavbarLoggedComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    NavbarComponent
  ]
})

export class NavbarModule {}
