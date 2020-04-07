import { NgModule } from '@angular/core';
import { RegistrationModalComponent } from './registrationForm.component';
import { ValidationDirective } from './validation.directive';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

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
  exports: [

  ]
})

export class RegistrationModule {}
