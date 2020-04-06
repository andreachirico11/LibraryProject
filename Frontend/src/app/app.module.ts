import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormControlDirective } from '@angular/forms';
import { RegistrationModule } from './registrationForm/registration.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { UserModule } from './user/user.module';
import { RouterModule, Routes } from '@angular/router';
import { LibraryModule } from './library/library.module';
import { AdminModule } from './admin/admin.module';

import { AppComponent } from './app.component';
import { BodyComponent } from './body/body.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { PlaceholderDirective } from './shared/placeholder.directive';

// import { MockInterceptorService } from './shared/mockInterceptors/mockAuth.service';
// import { MockCreateUserService } from './shared/mockInterceptors/mockPostUser.service';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full' },
  {path: 'home', component: HomeComponent },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];


@NgModule({
  declarations: [
    AppComponent,
    BodyComponent,
    HomeComponent,
    NavbarComponent,
    PlaceholderDirective,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    LibraryModule,
    UserModule,
    AdminModule,
    RegistrationModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    // {
    //   provide: HTTP_INTERCEPTORS, useClass: MockInterceptorService, multi: true
    // },
    // {
    //   provide: HTTP_INTERCEPTORS, useClass: MockCreateUserService, multi: true
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
