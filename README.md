# Booking Portal
The main goal of the project is to practice and review techniques and skills that have already been learned.


![alt text](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/schema.png "Booking application base schema")


## Tools & Technics Set
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [gRPC](https://learn.microsoft.com/en-us/aspnet/core/grpc)
- [AutoMapper](https://automapper.org/)
- [Unit Tests](https://github.com/arthurberzin/k8s-saga-booking-portal/tree/main/tests)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/), [SQL Server](https://learn.microsoft.com/en-us/ef/core/providers/sql-server), [In-Memory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory), [Eager Loading](https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager)
- [Health Checks](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks) for 'liveness' , memory chech
- [Serilog](https://serilog.net/)

## TODO

- Integrate health check with k8s 'liveness'
- Add EF context Health Check
- Booking engine for Airline Service, implement time to book a place
- Add functional of pagination
- Implement SAGA

## Features
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)  In this solution, you can find the use of Clean Architecture. The solution has different services with Clean Architecture structure.
- The [Open Cage API](https://opencagedata.com/) was used to retrieve the longitude and latitude coordinates of a specific location, such as a city or airport. This information was then used to calculate the distance between two points using the [Haversine formula](https://en.wikipedia.org/wiki/Haversine_formula). *You can find its implementation in* [Car Rent Service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/CarRentService/CarRentApplication/DistanceCalculator.cs)
- In this project, a comprehensive Airlines Database Schema was implemented using `Entity Framework` and various configuration options. *More info in* [Airline Service](https://github.com/arthurberzin/k8s-saga-booking-portal/tree/main/src/AirlineService).
- The [Options Pattern](https://learn.microsoft.com/en-us/dotnet/core/extensions/options) is utilized in the solution to retrieve application settings as an injectable model with settings. *Using of Options could be found in* [Car Rent Service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/CarRentService/API/Program.cs).
- The [gRPC](https://learn.microsoft.com/en-us/aspnet/core/grpc) was utilized to retrieve a large amount of data in a single cluster. It provides the ability to quickly retrieve a large amount of data without any problems caused by network instability.
- The [Strategy pattern](https://en.wikipedia.org/wiki/Strategy_pattern) was utilized here to offer a flexible mechanism for modifying the filter condition. *Using is in* [airlines service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineApplication/FilterStrategies/DepartureAndArrivalDateFilterStrategy.cs), [car rent service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/CarRentService/CarRentApplication/FlitersStrategies/CityAndDateFlitersStrategy.cs) and [hotel rent service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/HotelService/HotelApplication/FlitersStrategies/DateHotelFilterStrategy.cs).
- In the solution, you will find the use of [FluentValidation](https://docs.fluentvalidation.net/en/latest/) in two different contexts. It is used as a fundamental component in the [airline service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineApplication/Validators/FlightsRequestValidator.cs), and it is employed as an interceptor in the [car rental service](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/CarRentService/CarRentApplication/GrpcService/FluentValidationInterceptor.cs), making it more complex.

## Kubernetes

### Run application

##### 1) Update Host File
###### *C:\Windows\System32\drivers\etc\host*

```notepud
127.0.0.1 bookingportal.com
```


##### 2) Run bat script
###### *Go to [solutionfolder]\k8s*
```powershell
.\deploy-k8s.bat
```

##### 3) Go to [bookingportal.com](bookingportal.com)

### Destroy application
###### *Go to [solutionfolder]\k8s*
```powershell
.\destroy-k8s.bat
```

## Build & Push Docker Images

##### Booking Portal
```powershell
docker buildx build --platform linux/amd64 --push -f src\WebPortal\Portal\Dockerfile -t <docker hub id>/webportal .
```

##### Supportal 
```powershell
 docker buildx build --platform linux/amd64 --push -f src\Supportal\Portal\Dockerfile -t <docker hub id>/supportal .
```

##### RabbitMQ
```powershell
docker pull rabbitmq
```

##### Booking Service 
```powershell
docker buildx build --platform linux/amd64 --push -f src\BookingService\API\Dockerfile -t <docker hub id>/bookingapi .
```

##### Billing Service 
```powershell
docker buildx build --platform linux/amd64 --push -f src\BillingService\API\Dockerfile -t <docker hub id>/billingapi .
```

##### Hotel Service 
```powershell
docker buildx build --platform linux/amd64 --push -f src\HotelService\API\Dockerfile -t <docker hub id>/hotelapi .
```

##### Car Rent Service 
```powershell
docker buildx build --platform linux/amd64 --push -f src\CarRentService\API\Dockerfile -t <docker hub id>/carrentapi .
```

##### Airline Service
```powershell
docker buildx build --platform linux/amd64 --push -f src\AirlineService\API\Dockerfile -t <docker hub id>/airlineapi .
```




## Local Run Docker Images

##### Booking Portal
```powershell
docker run -p 8080:80 -d <docker hub id>/webportal
```

##### Supportal
```powershell
docker run -p 8070:80 -d <docker hub id>/supportal
```

##### RabbitMQ
```powershell
docker run -d --hostname my-rabbit --name booking-rabbit -p 8660:15672 -p 8060:5672 rabbitmq:3-management
```
> RabbitMQ portal [http://localhost:8660](http://localhost:8660) default credentials of guest/guest.

##### Booking Service 
```powershell
docker run -p 8050:80 -d <docker hub id>/bookingapi
```

##### Billing Service 
```powershell
docker run -p 8040:80 -d <docker hub id>/billingapi
```

##### Hotel Service 
```powershell
docker run -p 8030:80 -d <docker hub id>/hotelapi
```

##### Car Rent Service  
```powershell
docker run -p 8020:80 -d <docker hub id>/carrentapi
```

##### Airline Service
```powershell
docker run -p 8010:80 -d <docker hub id>/airlineapi
```
