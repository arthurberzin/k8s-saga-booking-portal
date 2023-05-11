import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public hotels: Hotel[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Hotel[]>(baseUrl + 'data').subscribe(result => {
      this.hotels = result;
    }, error => console.error(error));
  }
}


interface Hotel {
  id: string;
  name: string;
  description: string;
  reviewScore: number;
  maxPeople: number;
  address: string;
  occupateDates: number[];
  images: string[];
  prices: Price[];
}

interface Price {
  price: number;
  fromDay: number;
  toDay: number;
}
