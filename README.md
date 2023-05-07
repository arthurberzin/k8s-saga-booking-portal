# Booking Portal
The main goal of the project is to practice and review techniques and skills that have already been learned.


![alt text](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/schema.png "Booking application base schema")


## Tools & Technics Set
- [AutoMapper](https://automapper.org/)
- [Unit Tests](https://github.com/arthurberzin/k8s-saga-booking-portal/tree/main/tests)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) , [In-Memory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory), [Eager Loading](https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager)
- [Health Checks](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks) for 'liveness' , memory chech
- [Serilog](https://serilog.net/)

## TODO

- Integrate health check with k8s 'liveness'
- Add EF context Health Check
- Booking engine for Airline Service, implement time to book a place

## Features
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)  In this solution, you can find the use of Clean Architecture. The solution has different services with Clean Architecture structure.
- The [Open Cage API](https://opencagedata.com/) was used to retrieve the longitude and latitude coordinates of a specific location, such as a city or airport. This information was then used to calculate the distance between two points using the [Haversine formula](https://en.wikipedia.org/wiki/Haversine_formula). *You can find its implementation in* [Car Rent Service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/CarRentService/CarRentApplication/DistanceCalculator.cs)
- In this project, a comprehensive Airlines Database Schema was implemented using `Entity Framework` and various configuration options. *More info in* [Airline Service](https://github.com/arthurberzin/k8s-saga-booking-portal/tree/main/src/AirlineService).

## Build Docker Images

#### Booking Portal
```powershell
docker build -f src\WebPortal\Portal\Dockerfile -t <docker hub id>/webportal .
```

#### Supportal 
```powershell
 docker build -f src\Supportal\Portal\Dockerfile -t <docker hub id>/supportal .
```

#### RabbitMQ
```powershell
docker pull rabbitmq
```

#### Booking Service 
```powershell
docker build -f src\BookingService\API\Dockerfile -t <docker hub id>/bookingapi .
```

#### Aggregator Service 
```powershell
docker build -f src\AggregatorService\API\Dockerfile -t <docker hub id>/aggregatorgapi .
```

#### Hotel Service 
```powershell
docker build -f src\HotelService\API\Dockerfile -t <docker hub id>/hotelapi .
```

#### Car Rent Service 
```powershell
docker build -f src\CarRentService\API\Dockerfile -t <docker hub id>/carrentapi .
```

#### Airline Service
```powershell
docker build -f src\AirlineService\API\Dockerfile -t <docker hub id>/airlineapi .
```




## Run Docker Images

#### Booking Portal
```powershell
docker run -p 8080:80 -d <docker hub id>/webportal
```

#### Supportal
```powershell
docker run -p 8070:80 -d <docker hub id>/supportal
```

#### RabbitMQ
```powershell
docker run -d --hostname my-rabbit --name booking-rabbit -p 8660:15672 -p 8060:5672 rabbitmq:3-management
```
> RabbitMQ portal [http://localhost:8660](http://localhost:8660) default credentials of guest/guest.

#### Booking Service 
```powershell
docker run -p 8050:80 -d <docker hub id>/bookingapi
```

#### Aggregator Service 
```powershell
docker run -p 8040:80 -d <docker hub id>/aggregatorgapi
```

#### Hotel Service 
```powershell
docker run -p 8030:80 -d <docker hub id>/hotelapi
```

#### Car Rent Service  
```powershell
docker run -p 8020:80 -d <docker hub id>/carrentapi
```

#### Airline Service
```powershell
docker run -p 8010:80 -d <docker hub id>/airlineapi
```
