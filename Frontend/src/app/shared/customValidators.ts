import { FormControl, AbstractControl } from "@angular/forms";

export class CustomValidators {
  regexPatterns = {
    hasNumber: /\d/,
    hasCapitaCase: /[A-Z]/,
    asSmallCase: /[a-z]/,
    hasSpecialCaracters: /^[a-zA-Z0-9!@#\$%\^\&*\)\(+=._-]{6,}$/g
  };

  passwordValidator(
    abstractControl: AbstractControl
  ): { [message: string]: boolean } {
    let testResult = null;
    const password = abstractControl.value;
    if (!password) {
      return testResult;
    }
    // for (const regex in this.regexPatterns) {
    //   const pattern = this.regexPatterns[regex];
    //   console.log(pattern);
    //   pattern.test(password) ? (testResult = true) : null;
    // }

    /\d/.test(password)

    return testResult;
  }
}
