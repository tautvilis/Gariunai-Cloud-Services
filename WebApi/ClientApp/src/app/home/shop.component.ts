import {Component, OnInit, Input, ViewChild, Inject, ViewEncapsulation, NgModule} from '@angular/core';
import { NgbActiveModal, NgbPaginationNumber } from '@ng-bootstrap/ng-bootstrap';
import {AgmCoreModule, AgmMap, MapsAPILoader} from '@agm/core';
import {MatGridListModule} from '@angular/material/grid-list';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Account} from '../_services/account.service';
import keys from '../_other/keys.json';
import {BrowserModule} from "@angular/platform-browser";
import LatLng = google.maps.LatLng;


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['home.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ShopComponent implements OnInit {
  @Input() public shop:Shop;
  public produce: Produce[];

  map:any;
  marker:any;

  coords: number;
  lats :any;
  lngs : any;
  page = 1;
  pageSize= 4;
  collectionSize: number;
  _isFollowing: boolean = false;
  private geoCoder;
  apiLoaded : boolean;


  constructor(public activeModal: NgbActiveModal, private mapsAPILoader: MapsAPILoader,private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,private accountService: Account,) {

  }
  ngOnInit() {
    this.mapsAPILoader.load().then(() => {
      this.apiLoaded = true;
      this.geoCoder = new google.maps.Geocoder;
      this.codeAddress(this.shop.location);
      this.isFollowing(this.shop.id);
      this.getProduce();
    });
  }



  private error(err) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
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
  public codeAddress(address) {
    this.geoCoder.geocode({ 'address': address }, function (results, status) {
      let latLng = {lat: results[0].geometry.location.lat(), lng: results[0].geometry.location.lng()};
      if (status == 'OK') {
        this.lats = latLng.lat;
        this.lngs = latLng.lng;
        console.log (latLng.lat);
      }
      else {
        alert('Geocode was not successful for the following reason: ' + status);
      }
    });
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


