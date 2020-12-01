import { Injectable } from '@angular/core';
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
    private http: HttpClient
  ) {
    this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('authKey')));
   }

   public get userValue(): User {
     return this.userSubject.value;
   }

   login(username,password) {
     var auth = btoa(username +":"+ password);
     const body = {Authorization: "Basic "+ auth};
     const requestOptions = {headers: new HttpHeaders(body)};
    
     return this.http.get<User>('Api/Users/Authorize', requestOptions).pipe(map(user => {
       localStorage.setItem('authKey',JSON.stringify(auth));
       this.userSubject.next(user);
       return user;
     }))
    }

   logout() {
    localStorage.removeItem('authKey');
    this.userSubject.next(null);
    this.router.navigate(['/']);
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
