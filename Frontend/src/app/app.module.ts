import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { BodyComponent } from './body/body.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RegistrationModalComponent } from './registrationForm/registrationForm.component';
import { LibraryModule } from './library/library.module';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MockInterceptorService } from './shared/mockInterceptors/mockAuth.service';
import { UserModule } from './user/user.module';
import { PlaceholderDirective } from './registrationForm/placeholder.directive';
import { MockCreateUserService } from './shared/mockInterceptors/mockPostUser.service';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'},
];


@NgModule({
  declarations: [
    AppComponent,
    BodyComponent,
    NavbarComponent,
    RegistrationModalComponent,
    HomeComponent,
    PlaceholderDirective
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    LibraryModule,
    UserModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: MockInterceptorService, multi: true
    },
    {
      provide: HTTP_INTERCEPTORS, useClass: MockCreateUserService, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
