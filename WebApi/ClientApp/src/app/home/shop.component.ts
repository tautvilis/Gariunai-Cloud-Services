import {Component, OnInit, Input, ViewChild, Inject, ViewEncapsulation, NgModule} from '@angular/core';
import { NgbActiveModal, NgbPaginationNumber } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Account} from '../_services/account.service';


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
  isGeolocated : boolean = false;
  _isFollowing: boolean = false;
  marker: google.maps.LatLngLiteral;
  zoom = 12;
  center: google.maps.LatLngLiteral;
  constructor(public activeModal: NgbActiveModal, private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,private accountService: Account,) {


  }
  ngOnInit() {
    const geocoder = new google.maps.Geocoder();
    this.isFollowing(this.shop.id);
    this.getProduce();
    this.geocodeAddress(geocoder);
  }
  addMarker(lat, lng) {
    this.marker = {
        lat: lat,
        lng: lng,
    }
    this.center = this.marker;
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
  public geocodeAddress(geocoder: google.maps.Geocoder) {
    const address = this.shop.location;
    geocoder.geocode({ address: address }, (results, status) => {
      if (status === "OK") {
          this.addMarker(results[0].geometry.location.lat(), results[0].geometry.location.lng())
          this.isGeolocated = true;
      }
      else {
        alert("Geocode was not successful for the following reason: " + status);
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


