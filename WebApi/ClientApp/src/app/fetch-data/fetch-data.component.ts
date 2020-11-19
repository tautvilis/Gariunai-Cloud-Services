import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public shop: Shops[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Shops[]>(baseUrl + 'api/shops').subscribe(result => {
      this.shop = result;
    }, error => console.error(error));
  }

  getUserByName(username){
  }

}


interface Shops {
  id: number;
  name: string;
  description: string;
  location: string;
}
