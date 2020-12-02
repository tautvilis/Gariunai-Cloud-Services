import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {Account} from '../_services/account.service';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit {
  form: FormGroup;
  loggedIn = false;
  IsEmptyUser: string;


  get LoggedIn(){
    return this.loggedIn;
  }

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private accountService: Account,
    private navMenu: NavMenuComponent
  ) { }

  ngOnInit(){
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required,Validators.minLength(5)]]
  });
  }

  get f() { return this.form.controls; }

  getUserErrorMessage() {
    if (this.f.username.hasError('required')) {
      return 'You must enter a value';
    }
    return this.f.username.hasError('email') ? 'Not a valid email' : '';
  }
  getPassErrorMessage() {
    if(this.f.password.hasError('required')){
      return 'You must enter a value';
    }
    if(this.f.password.hasError('minLength')){
      return 'You must enter a value that is longer than 6 symbols'
    }
  }



  onSubmit(){
    if (this.form.invalid) {
      return;
    }
    console.log("Logged in with:" + this.f.username.value + " " + this.f.password.value);
    this.accountService.login(this.f.username.value, this.f.password.value)
      .subscribe({
        next: () => {
          this.router.navigateByUrl('/home');
          this.navMenu.toggle();
        },
        error: error => {
          console.log(error);
        }
      },)
      this.form.reset();
  }

  onRegister() {
    if (this.form.invalid) {
      return;
    }
  }
}
class User {
  username: string;
  password: string;
}
