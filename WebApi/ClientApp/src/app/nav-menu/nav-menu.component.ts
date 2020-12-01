import { ThrowStmt } from '@angular/compiler';
import { Component, Input } from '@angular/core';
import { NavMenuService } from './nav-menu.service';
import {Account} from '../_services/account.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(public nav: NavMenuService, private accountService: Account,){}

  isExpanded = false;

  logout() {
    this.accountService.logout();
    console.log("logged out");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
