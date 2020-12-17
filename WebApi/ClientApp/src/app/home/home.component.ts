import { Component, Input, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ShopComponent } from './shop.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {Account} from '../_services/account.service';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['home.component.css']
})


export class HomeComponent implements OnInit {
  public shop: Shops[];
  public notifications: Notifications[];
  pageEvent: PageEvent;
  length:number;
  pageSize = 10;
  pageSizeOptions: number[] = [5,10,50];

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private modalService: NgbModal,
    private accountService: Account,
    )
    {  
      http.get<Shops[]>(baseUrl + 'api/shops').subscribe(result => {
        this.shop = result;
        this.length = this.shop.length;
        }, error => console.error(error));

      const body = {Authorization: "Basic "+ JSON.parse(localStorage.getItem('authKey'))};
      const requestOptions = {headers: new HttpHeaders(body)};
      this.http.get<Notifications[]>(this.baseUrl + 'api/notifications', requestOptions).subscribe(result => {
        this.notifications = result;
        }, error => console.error(error));
    }
  ngOnInit(): void {
    const body = {Authorization: "Basic "+ JSON.parse(localStorage.getItem('authKey'))};
      const requestOptions = {headers: new HttpHeaders(body)};
      this.http.get<Notifications[]>(this.baseUrl + 'api/notifications', requestOptions).subscribe(result => {
        this.notifications = result;
        }, error => console.error(error));
  }
  refreshNotifications()  {
    const body = {Authorization: "Basic "+ JSON.parse(localStorage.getItem('authKey'))};
      const requestOptions = {headers: new HttpHeaders(body)};
      this.http.get<Notifications[]>(this.baseUrl + 'api/notifications', requestOptions).subscribe(result => {
        this.notifications = result;
        }, error => console.error(error));
  }




  openModal(shop:any) {
    const modal = this.modalService.open(ShopComponent, {size:'xl'});
    modal.componentInstance.shop = shop;
  }

  getShopNameById(shopid: number){
    let name = this.shop.find(x=>x.id == shopid).name;
    return name;
  }


}


interface Shops {
  id: number;
  name: string;
  description: string;
  location: string;
  longDescription: string;
  contacts: string;
}


interface Notifications {
  shopId: number;
  title: string;
  description: string;
  image: string;
  shopName: string;
  
}
