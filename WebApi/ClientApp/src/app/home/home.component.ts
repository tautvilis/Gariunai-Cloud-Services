import { Component, Input, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShopComponent } from './shop.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['home.component.css']
})


export class HomeComponent {
  public shop: Shops[];

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private modalService: NgbModal,

    )
    {
    http.get<Shops[]>(baseUrl + 'api/shops').subscribe(result => {
      this.shop = result;
    }, error => console.error(error));
  }

  openModal(shop:any) {
    const modal = this.modalService.open(ShopComponent);
    modal.componentInstance.shop = shop;

  }

  data(data: string){

  }


}


interface Shops {
  id: number;
  name: string;
  description: string;
  location: string;
}
