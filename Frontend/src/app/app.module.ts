import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { RegistrationModule } from './registrationForm/registration.module';
import { UserModule } from './user/user.module';
import { LibraryModule } from './library/library.module';
import { AdminModule } from './admin/admin.module';
import { NavbarModule } from './navbar/navbar.module';

import { AppComponent } from './app.component';
import { BodyComponent } from './body/body.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';

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
    FooterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    LibraryModule,
    UserModule,
    AdminModule,
    RegistrationModule,
    NavbarModule,
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
  bootstrap: [AppComponent, NavbarComponent]
})
export class AppModule { }
