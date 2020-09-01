import { FormControl, FormGroup } from '@angular/forms';

export function validateFormFields(formGroup: FormGroup) {
  Object.keys(formGroup.controls).forEach((field) => {
    const control = formGroup.get(field);
    if (control instanceof FormControl)
      control.markAsTouched({ onlySelf: true });
    else if (control instanceof FormGroup)
      this.validarCamposForm(control);
  });
}
