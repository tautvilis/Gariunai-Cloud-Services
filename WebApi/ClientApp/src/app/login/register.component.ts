import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {Account} from '../_services/account.service';
import { registerLocaleData } from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['login.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  hasError = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: Account,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(5)]],

  });
  }
  get f() { return this.form.controls; }

  getEmailErrorMessage() {
    if(this.f.email.hasError('required')){
      return 'you must enter a value';
    }
    return this.f.email.hasError('email') ? 'Not a valid email' : '';
  }

  getUserErrorMessage() {
    if (this.f.username.hasError('required')) {
      return 'You must enter a value';
    }
  }
  getPassErrorMessage() {
    if(this.f.password.hasError('required')){
      return 'You must enter a value';
    }
    if(this.f.password.hasError('minLength')){
      return 'You must enter a value that is longer than 6 symbols'
    }
  }
  
  onSubmit() {
    this.submitted = true;

    if(this.form.invalid) {
      return;
    }
    this.accountService.register(this.f.email.value, this.f.username.value, this.f.password.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/login');
      },
      error: error => {
        console.log(error);
        this.hasError = true;
      }
    },)
    this.form.reset();

    
  }
}
