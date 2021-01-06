import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import {Account} from '../../_services/account.service';

@Component({
  selector: 'app-editshop',
  templateUrl: './editshop.component.html',
  styleUrls: ['./editshop.component.css']
})
export class EditshopComponent implements OnInit {

  public shop: Shops[];
  public notification: Notifications[];
  form: FormGroup;
  public produce: Produce[];
  public shopID: number;
  private ownerID: any;
  private image: any;
  private uploaded: boolean = false;
  public files: File[] = [];
  

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

  onSelect(event) {
    console.log(event);
    if(this.files.length < 3 ){
      this.files.push(...event.addedFiles);
    }
    
  }

  onRemove(event) {
    console.log(event);
    this.files.splice(this.files.indexOf(event),1);
  }

  onFilesAdded(event) {
    console.log("test2",event);
    this.files.push(...event.addedFiles);
  
    this.readFile(this.files[0]).then(fileContents => {
      // Put this string in a request body to upload it to an API.
      console.log("ikelti failai",fileContents);
    })
  }
  
  private async readFile(file: File): Promise<string | ArrayBuffer> {
    return new Promise<string | ArrayBuffer>((resolve, reject) => {
      const reader = new FileReader();
  
      reader.onload = e => {
        return resolve((e.target as FileReader).result);
      };
  
      reader.onerror = e => {
        console.error(`FileReader failed on file ${file.name}.`);
        return reject(null);
      };
  
      if (!file) {
        console.error('No file to read.');
        return reject(null);
      }
  
      reader.readAsDataURL(file);
    });
  }
  ngOnInit(): void {
    this.ownerID =JSON.parse(localStorage.getItem('id')); 
  
    this.form = this.formBuilder.group({
      shopName: ['', ],
      shopDesc: ['', ],
      shopLongDesc: ['', ],
      shopLocation: ['', ],
      shopNumber: ['',],
      image:['',]
  });
  }
  get f() { return this.form.controls; }

  sendNotification(){
    let notificationInfo: Notifications = {
      shopId: this.shopID,
      title: (document.getElementById("notificationTitle") as HTMLInputElement).value,
      description: (document.getElementById("notificationInfo") as HTMLInputElement).value,
      image:this.image,
    }

    this.http.post(this.baseUrl + 'api/shops/'+this.shopID+'/notifications',notificationInfo,
    {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
    .subscribe(result => {console.log(notificationInfo);}, error => console.log(error));
    this.showNotifications();
  }
  showNotifications():Observable<Notifications[]>{
    return this.http.get<Notifications[]>(this.baseUrl + 'api/shops/' + this.shopID+'/notifications');
  }
  delNotification(id:any){
    if(confirm("Ar tikrai norite istrinti?")){
      this.http.delete(this.baseUrl + 'api/shops/' + this.shopID + '/notification',
      {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))}), params: {notificationId:id}})
      .subscribe(() => console.log('delete successful'));
      this.showNotifications();
    }
  }

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
    this.showNotifications().subscribe(res => {
      this.notification = res;
    })  
  }

  saveImage(type:number){
    let formdata:any = new FormData();
    if(type == 3) {formdata.append("image",(document.getElementById("imageNotificationInput") as HTMLInputElement).files[0]);}
    else{formdata.append("image",(document.getElementById("imageInput") as HTMLInputElement).files[0]);}
    return this.http.post(this.baseUrl + 'api/images',formdata)
    .subscribe(result=>{ this.image = result;if(type == 1) {this.newShop();}else if(type == 2){this.updateShop();}else{this.sendNotification();}}, error=>{console.log(error);});
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

   updateShop() {
    let newInfo: Shops = {
      id: this.shopID,
      ownerId: this.ownerID,
      name:(document.getElementById("shopName") as HTMLInputElement).value,
      description:(document.getElementById("shopDesc") as HTMLInputElement).value,
      longDescription:(document.getElementById("shopLongDesc") as HTMLInputElement).value,
      location:(document.getElementById("shopLocation") as HTMLInputElement).value,
      contacts:(document.getElementById("shopNumber") as HTMLInputElement).value,
      image1: this.image,
    };
    this.http.put<Shops>(this.baseUrl + 'api/shops/' + this.shopID ,newInfo,
    {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
    .subscribe(result => {this.updateShopList();}, error => console.log(error));
  }

   newShop(){
     let newShop: Shops = {
      ownerId: this.ownerID,
      name:(document.getElementById("shopName") as HTMLInputElement).value,
      description:(document.getElementById("shopDesc") as HTMLInputElement).value,
      longDescription:(document.getElementById("shopLongDesc") as HTMLInputElement).value,
      location:(document.getElementById("shopLocation") as HTMLInputElement).value,
      contacts:(document.getElementById("shopNumber") as HTMLInputElement).value,
      image1: this.image,
    };
    
    this.http.post(this.baseUrl + 'api/shops/',newShop,
    {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
    .subscribe(result => {this.updateShopList();}, error => console.log(error));
  }

  delShop(id){
    if(confirm("Ar tikrai norite istrinti?")){
      this.http.delete(this.baseUrl + 'api/shops/' + id,
      {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
      .subscribe(() => console.log('delete successful'));
      this.updateShopList();
    }
    
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
  image1: any;
}

export interface Notifications {
  id?: number;
  shopId: number;
  title: string;
  description: string;
  image?: any;

}
