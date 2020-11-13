import { Component } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['home.component.css']
})
export class HomeComponent {
  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required, Validators.minLength(6)])

  getErrorMessage() {
    if (this.username.hasError('required')) {
      return 'You must enter a value';
    }

    if(this.password.hasError('required') || this.password.hasError('minLength')){
      return 'You must enter a value that is longer than 6 symbols';
    }

    return this.username.hasError('email') ? 'Not a valid email' : '';
  }
}
