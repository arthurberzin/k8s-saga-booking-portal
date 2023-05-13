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

/*
function durationToDate(duration: google.protobuf.IDuration): Date {
  const date = new Date();
  const ms = duration.seconds * 1000 + duration.nanos / 1000000;
  date.setTime(date.getTime() + ms);
  return date;
}
*/

interface Duration {
  seconds: number;
  nanos: number;
}

const duration: Duration = {
  seconds: 5,
  nanos: 0
};

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
  occupiedDates: number[];
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
  departureDateTime: Duration;
  arrivalDateTime: Duration;
  flightDuration: Duration;
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
  occupateDates: number[];
  images: string[];
  prices: Price[];
}

interface Price {
  price: number;
  fromDay: number;
  toDay: number;
}
