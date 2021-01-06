import { Component, OnInit, Input, ViewChild, Inject, ViewEncapsulation} from '@angular/core';
import { NgbActiveModal, NgbPaginationNumber } from '@ng-bootstrap/ng-bootstrap';
import {AgmMap,MapsAPILoader  } from '@agm/core';  
import {MatGridListModule} from '@angular/material/grid-list';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Account} from '../_services/account.service';
import keys from '../_other/keys.json';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['home.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class ShopComponent implements OnInit {
  @Input() public shop:Shop;
  public produce: Produce[];

  page = 1;
  pageSize= 4;
  collectionSize: number;

  _isFollowing: boolean = false;
  
  

  constructor(public activeModal: NgbActiveModal,private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,private accountService: Account,) { }
  ngOnInit() {
    
    this.isFollowing(this.shop.id);
    this.getProduce();
    
  }
  

  public getProduce(){
    this.http.get<Produce[]>(this.baseUrl + 'api/shops/'+ this.shop.id + '/Produce').subscribe((result) => {
      this.produce = result;
      this.collectionSize = this.produce.length;
    }, error => console.error(error));
  }


  public follow(shopid: number, state:string) {
    this.accountService.followShop(shopid,state)
  }

  public isFollowing(shopid: number){
    this.http.get(this.baseUrl + "api/shops/"+ shopid + "/follow", 
     {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
     .subscribe(result => { 
       if(result == true){
         this._isFollowing = true;
        }else if (result == false){
          this._isFollowing = false;
        }},
      error => console.error(error));
  }
  close(){
    this._isFollowing== false;
  }
  

} 


interface Shop {
  id: number;
  name: string;
  description: string;
  location: string;
  contacts: string;
  longDescription: string;
}


export interface Produce {
  name: string;
}


