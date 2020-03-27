import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { faCheck, faEnvelope, faUser , faMap, faCity, faPhone , faWindowClose} from '@fortawesome/free-solid-svg-icons';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { User } from '../shared/models/userModel';


@Component({
  selector: 'app-registration',
  templateUrl: './registrationForm.component.html',
  styleUrls: ['./registration.component.css']
})
// styles: ['input.ng-invalid {border: 5px solid red}']

export class RegistrationModalComponent implements OnInit {
  public iconsArray = [faCheck, faEnvelope, faUser , faMap, faCity, faPhone, faWindowClose];
  registrationForm: FormGroup;

  @Output() closeEvent = new EventEmitter<void>()

  ngOnInit() {
    this.registrationForm = new FormGroup({
      'name': new FormControl('', [Validators.required]),
      'surname': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]),
      'email': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.email]),
      'adress': new FormControl('', [Validators.required]),
      'city': new FormControl('', [Validators.required]),
      'phoneNumber': new FormControl('', [Validators.required, Validators.minLength(10)])
    });
  }

  close() {
    this.closeEvent.emit();
  }

  // createUser(): User {
  //   return new User()
  // }

  submit() {
    console.log(
      this.registrationForm.get('name').value

    );

  }



}
