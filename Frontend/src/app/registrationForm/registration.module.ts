import { NgModule } from '@angular/core';
import { RegistrationModalComponent } from './registrationForm.component';
import { ValidationDirective } from './validation.directive';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { PhotoAdderInterceptor } from './photoAdderInterceptor.service';

@NgModule({
  declarations: [
    RegistrationModalComponent,

    ValidationDirective
  ],
  imports: [
    FontAwesomeModule,
    ReactiveFormsModule,
    BrowserModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: PhotoAdderInterceptor, multi: true
    }
  ]
})

export class RegistrationModule {}
