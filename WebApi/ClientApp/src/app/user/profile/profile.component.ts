import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  private userID: any;
  public user: User;
  public image: any;

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
  ) {
    this.userID =JSON.parse(localStorage.getItem('id'));
    http.get<User>(baseUrl + 'api/Users/'+ this.userID).subscribe(result => {
      this.user = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }
  saveChanges(){
    let newInfo: User = {
      id: this.userID,
      name:(document.getElementById("userName") as HTMLInputElement).value,
      description:(document.getElementById("userDesc") as HTMLInputElement).value,
      email : (document.getElementById("userEmail") as HTMLInputElement).value,
      profilePicture: this.image,
    };
    this.http.put<User>(this.baseUrl + 'api/Users/' + this.userID ,newInfo,
      {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
      .subscribe(result => {this.updateUser();}, error => console.log(error));
  }
  updateUser(){
    this.http.get<User>(this.baseUrl + 'api/Users/'+ this.userID).subscribe(result => {
      this.user = result;
    }, error => console.error(error));
  }
  saveImage(){
    let formdata:any = new FormData();
    
    formdata.append("image",(document.getElementById("image") as HTMLInputElement).files[0]);
    return this.http.post(this.baseUrl + 'api/images',formdata)
    .subscribe(result=>{ this.image = result;this.saveChanges(); }, error=>{console.log(error);});
  }

}
export interface User {
  id?: number;
  name: string;
  email: string;
  description: string;
  profilePicture: any;
}

