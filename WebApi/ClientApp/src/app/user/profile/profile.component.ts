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
      profilePicture: undefined
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

}
export interface User {
  id?: number;
  name: string;
  email: string;
  description: string;
  profilePicture: any;
}

