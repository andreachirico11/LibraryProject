import { FormControl, AbstractControl, FormGroup } from "@angular/forms";

const regexPatterns = {
  hasNumber: /\d/,
  hasCapitaCase: /[A-Z]/,
  hasSmallCase: /[a-z]/,
  hasSpecialCharacters: /[^A-Za-z0-9]/
};

export class CustomValidators {

  passwordValidator(
    abstractControl: AbstractControl
  ): { [message: string]: boolean } {
    const password = abstractControl.value;
    if (!password) {
      return null;
    } else if (!regexPatterns.hasNumber.test(password)) {
      return { 'noNumber': true };
    } else if (!regexPatterns.hasCapitaCase.test(password)) {
      return { 'noCapitalLetter': true };
    } else if (!regexPatterns.hasSmallCase.test(password)) {
      return { 'noSmallLetter': true };
    } else if (!regexPatterns.hasSpecialCharacters.test(password)) {
      return { 'noSpecialCharacter': true };
    } else {
      return null;
    }
  }

  cellPhoneValidator(
    abstractControl: AbstractControl
  ): { [message: string]: boolean } {
    const phoneNumber = abstractControl.value;

  if (regexPatterns.hasSmallCase.test(phoneNumber)) {
      return {'onlyNumbers': true}
    } else {
      return null;
    }
  }

  literalValidator(
    abstractControl: AbstractControl
  ): { [message: string]: boolean } {
    const field = abstractControl.value;
    if(regexPatterns.hasNumber.test(field)) {
      return {'onlyLetters': true}
    }
    if(regexPatterns.hasSpecialCharacters.test(field)) {
      return {'onlyLetters': true}
    }
    return null;
  }

  passwordComparer(
    abstractControl: FormGroup
  ): { [message: string]: boolean } {
    const password = abstractControl.get('password').value;
    const confirmPassword = abstractControl.get('confirmPassword').value;

    if(password !== confirmPassword) {
      return {'passwordsDoesntMatch': true}
    }
    return null;
  }

  nameSurnameComparer(
    abstractControl: FormGroup
  ): { [message: string]: boolean } {
    const name = abstractControl.get('name').value;
    const surname = abstractControl.get('surname').value;

    if(name === surname) {
      return {'name=surname': true}
    }
    return null;
  }
}
