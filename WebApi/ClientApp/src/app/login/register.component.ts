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
      }
    },)
    this.form.reset();

    
  }
}
