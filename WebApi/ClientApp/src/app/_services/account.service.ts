import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';



@Injectable({ providedIn: 'root'})
export class Account {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
  ) {
    this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('authKey')));
   }

   public get userValue(): User {
     return this.userSubject.value;
   }

   login(username,password) {
     let auth = btoa(username +":"+ password);
     const body = {Authorization: "Basic "+ auth};
     const requestOptions = {headers: new HttpHeaders(body)};

     return this.http.get<User>('Api/Users/Authorize', requestOptions).pipe(map(user => {
       localStorage.setItem('authKey',JSON.stringify(auth));
       this.userSubject.next(user);
       return user;
     }))
    }
  register(email,username,password) {
    const body = {name: username,email: email};
    return this.http.post('Api/Users?password='+password,body);
  }

  logout() {
    localStorage.removeItem('authKey');
    this.userSubject.next(null);
    this.router.navigate(['/']);
    }

  followShop(shopid: number, follow:string) {
    this.http.post(this.baseUrl + 'api/shops/' + shopid + '/follow/'+follow,{},
     {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
     .subscribe(result => { console.log(result);},
      error => console.error(error));
    }
  unfollowShop(shopid: number) {
      this.http.post(this.baseUrl + 'api/shops/' + shopid + '/follow/false',{},
       {headers: new HttpHeaders({'Authorization':'Basic '+ JSON.parse(localStorage.getItem('authKey'))})})
       .subscribe(result => { console.log(result);},
        error => console.error(error));
      }
}

export class User {
  id: string;
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  token: string;
}
