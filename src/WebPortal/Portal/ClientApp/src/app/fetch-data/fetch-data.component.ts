import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public hotels: Hotel[] = [];
  public flights: Flight[] = [];
  public cars: Car[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Hotel[]>(baseUrl + 'data/hotels').subscribe(result => {
      this.hotels = result;
    }, error => console.error(error));

    http.get<Car[]>(baseUrl + 'data/rentcars').subscribe(result => {
      this.cars = result;
    }, error => console.error(error));

    http.get<Flight[]>(baseUrl + 'data/flights').subscribe(result => {
      this.flights = result;
    }, error => console.error(error));
  }
}



interface Car {
  id: string;
  distance: number;
  name: string;
  imageUrl: string;
  type: string;
  transmission: string;
  seats: number;
  largeBag: number;
  smallBag: number;
  mileageLimit: number;
  pricePerDay: number;
  occupiedDates: Date[];
}

interface Flight {
  flightNumber: string;
  seatPrice: number;
  departureAirport: string;
  departureAirportCity: string;
  departureAirportCountry: string;
  arrivalAirport: string;
  arrivalAirportCity: string;
  arrivalAirportCountry: string;
  departureDateTime: Date;
  arrivalDateTime: Date;
  flightDuration: Date;
  aircraftNumber: string;
  aircraftType: string;
  aircraftCapacity: number;
  aircraftOccupiedCapacity: number;
}

interface Hotel {
  id: string;
  name: string;
  description: string;
  reviewScore: number;
  maxPeople: number;
  address: string;
  occupateDates: Date[];
  images: string[];
  prices: Price[];
}

interface Price {
  price: number;
  fromDay: number;
  toDay: number;
}
