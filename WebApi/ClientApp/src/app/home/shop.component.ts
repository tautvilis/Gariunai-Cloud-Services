import { Component, OnInit, Input, ViewChild} from '@angular/core';
import { NgbActiveModal, NgbPaginationNumber } from '@ng-bootstrap/ng-bootstrap';
import {Binary} from "@angular/compiler";
import {AgmMap,MapsAPILoader  } from '@agm/core';  
import { callbackify } from 'util';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['home.component.css']
})

export class ShopComponent implements OnInit {
  @Input() public shop:Shop;
  lat: number;
  lng: number;
  zoom: number;
  address: string;
  private geoCoder;
  coordinates: [number,number];

  constructor(public activeModal: NgbActiveModal, private apiloader: MapsAPILoader) { }
  ngOnInit() {
    this.apiloader.load().then(() =>{
      this.geoCoder = new google.maps.Geocoder;
      console.log(this.shop)
      this.setCurrentLocation();
      console.log(this.getCoords());
    })

  }


  private setCurrentLocation() {
    if('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
        this.zoom = 15;
      })
    }
  }

  private getCoords(){
    var result = "";
    this.geoCoder.geocode({'address': this.shop.location}, (results,status)=>{
      console.log(results);
      if(status === google.maps.GeocoderStatus.OK){
        if(results[0]) {
          this.lat = results[0].geometry.location.lat;
          this.lng = results[0].geometry.location.lng;
          console.log(this.lat, this.lng);
        }
      }
    })
  }
  
} 


interface Shop {
  id: number;
  name: string;
  description: string;
  location: string;
  contacts: string;
}
