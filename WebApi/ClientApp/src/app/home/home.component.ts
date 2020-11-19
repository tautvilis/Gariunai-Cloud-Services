import { Component, Input, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import {NavMenuComponent} from '../nav-menu/nav-menu.component';
import {NavMenuService} from '../nav-menu/nav-menu.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(
    public nav: NavMenuService
) { }

  ngOnInit(){
  }

}
