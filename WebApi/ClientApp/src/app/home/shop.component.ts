import { Component, OnInit, Input} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import {Binary} from "@angular/compiler";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
})

export class ShopComponent implements OnInit {
  @Input() public shop:Shop;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
    console.log(this.shop)
  }

}
interface Shop {
  id: number;
  name: string;
  description: string;
  location: string;
}
