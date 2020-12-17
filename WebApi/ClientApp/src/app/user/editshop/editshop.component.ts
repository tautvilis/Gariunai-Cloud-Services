import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {Account} from '../../_services/account.service';

@Component({
  selector: 'app-editshop',
  templateUrl: './editshop.component.html',
  styleUrls: ['./editshop.component.css']
})
export class EditshopComponent implements OnInit {

  public shop: Shops[];
  form: FormGroup;
  public produce: Produce[];
  public shopID: number;
  private ownerID: any;
  

  constructor(
    public http: HttpClient,
    private formBuilder: FormBuilder,
    @Inject('BASE_URL') public baseUrl: string,
    private accountService: Account,
  ) { 
    http.get<Shops[]>(baseUrl + 'api/shops').subscribe(result => {
      let shops = result;
      this.shop = shops.filter(x => x.ownerId === JSON.parse(localStorage.getItem('id')));
      console.log(this.shop);
      }, error => console.error(error));

  }

  
  ngOnInit(): void {
    this.ownerID =JSON.parse(localStorage.getItem('id')); 
    

    this.form = this.formBuilder.group({
      shopName: ['', ],
      shopDesc: ['', ],
      shopLongDesc: ['', ],
      shopLocation: ['', ],
      shopNumber: ['',],
  });
  }
  get f() { return this.form.controls; }

  updateShopList(){
    this.http.get<Shops[]>(this.baseUrl + 'api/shops').subscribe(result => {
      let shops = result;
      this.shop = shops.filter(x => x.ownerId === this.ownerID);
      }, error => console.error(error));
  }

  setInfo(id:number) {
    let _shop = this.shop.find(x=>{return x.id === id});
    (document.getElementById("shopName") as HTMLInputElement).value = _shop.name; 
    (document.getElementById("shopDesc") as HTMLInputElement).value = _shop.description;
    (document.getElementById("shopLongDesc") as HTMLInputElement).value = _shop.longDescription;
    (document.getElementById("shopLocation") as HTMLInputElement).value = _shop.location;
    (document.getElementById("shopNumber") as HTMLInputElement).value = _shop.contacts;
    this.getProduce(_shop.id); 
    this.shopID = _shop.id;   
  }

  private returnInfo(){
    let newInfo: Shops = {
      id: this.shopID,
      ownerId: this.ownerID,
      name:(document.getElementById("shopName") as HTMLInputElement).value,
      description:(document.getElementById("shopDesc") as HTMLInputElement).value,
      longDescription:(document.getElementById("shopLongDesc") as HTMLInputElement).value,
      location:(document.getElementById("shopLocation") as HTMLInputElement).value,
      contacts:(document.getElementById("shopNumber") as HTMLInputElement).value,
    };
    return newInfo;
  }

  updateShop() {
    this.http.put<Shops>(this.baseUrl + 'api/shops/' + this.shopID ,this.returnInfo(),
    {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
    .subscribe(result => {this.updateShopList();}, error => console.log(error));

  }

  getProduce(id:number){
    this.http.get<Produce[]>(this.baseUrl + 'api/shops/' + id + '/Produce').subscribe((result) => {
      this.produce = result;
    }, error => console.error(error));
  }

  addProduce(){
    let product = (document.getElementById("produceName") as HTMLInputElement).value;
    console.log(product);
    this.http.post(this.baseUrl + 'api/shops/' + this.shopID + '/Produce',{"name":product},
    {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
    .subscribe(result => {this.getProduce(this.shopID);}, error => console.log(error));
  }

  newShop(){
    let newShop: Shops = {
      ownerId: this.ownerID,
      name:(document.getElementById("shopName") as HTMLInputElement).value,
      description:(document.getElementById("shopDesc") as HTMLInputElement).value,
      longDescription:(document.getElementById("shopLongDesc") as HTMLInputElement).value,
      location:(document.getElementById("shopLocation") as HTMLInputElement).value,
      contacts:(document.getElementById("shopNumber") as HTMLInputElement).value,
    };
    
    this.http.post(this.baseUrl + 'api/shops/',newShop,
    {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
    .subscribe(result => {this.updateShopList();}, error => console.log(error));
    
  }

}

export interface Produce {
  name: string;
}

export interface Shops {
  ownerId: number;
  id?: number;
  name: string;
  description: string;
  location: string;
  longDescription: string;
  contacts: string;
}
