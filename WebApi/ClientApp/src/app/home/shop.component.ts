import { Component, OnInit, Input, ViewChild, Inject, ViewEncapsulation} from '@angular/core';
import { NgbActiveModal, NgbPaginationNumber } from '@ng-bootstrap/ng-bootstrap';
import {AgmMap,MapsAPILoader  } from '@agm/core';  
import {MatGridListModule} from '@angular/material/grid-list';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Account} from '../_services/account.service';
import tt from '@tomtom-international/web-sdk-maps';
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

  map:any;
  marker:any;

  currLat:any;
  currLng:any;

  coords: number;

  page = 1;
  pageSize= 4;
  collectionSize: number;

  _isFollowing: boolean = false;
  
  

  constructor(public activeModal: NgbActiveModal, private apiloader: MapsAPILoader,private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,private accountService: Account,) { }
  ngOnInit() {
    //this.getShopCoords();
    this.map = tt.map({
      key: 'jIvAmA6BfA1XvrNGFT7ZTld7hZ7PLin1',
      container: 'map',
      style: 'tomtom://vector/1/basic-main',
      zoom:1.2
    });
    this.getUserLocation().then(pos=>
    {
       console.log(`Positon: ${pos.lng} ${pos.lat}`);
       var coords = [pos.lng,pos.lat];
       var marker = new tt.Marker().setLngLat(coords).addTo(this.map);
    });
    
    this.isFollowing(this.shop.id);
    this.getProduce();
    
  }

  getUserLocation(): Promise<any>
  {
    return new Promise((resolve, reject) => {

      navigator.geolocation.getCurrentPosition(resp => {

          resolve({lng: resp.coords.longitude, lat: resp.coords.latitude});
        },
        err => {
          reject(err);
        });
    });
  }
  getShopCoords(){
    console.log(keys.tomtom);
    this.http.get("https://api.tomtom.com/search/2/geocode/"+encodeURI(this.shop.location)+".json?countrySet=LT&key=" + keys.tomtom).subscribe((result) => {
      console.log(JSON.stringify(result));
      this.coords = result[0].results[0].position;
      console.log(this.coords);
    }, error => console.error(error));
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


