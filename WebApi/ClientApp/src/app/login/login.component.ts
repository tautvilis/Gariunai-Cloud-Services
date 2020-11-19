import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import {NavMenuComponent} from '../nav-menu/nav-menu.component';
import { NavMenuService } from '../nav-menu/nav-menu.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit {
  form: FormGroup;
  loading = false;
  loggedIn = false;


  get LoggedIn(){
    return this.loggedIn;
  }

  constructor(
    private formBuilder: FormBuilder,
    private navMenu: NavMenuComponent,
    public nav: NavMenuService
  ) { }

  ngOnInit(){
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required,Validators.minLength(6)]]
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
    this.loading = true;
    console.log("Logged in with:" + this.f.username.value + " " + this.f.password.value);
    this.loading = false;
    this.navMenu.toggle();
    this.form.reset();
  }
}
