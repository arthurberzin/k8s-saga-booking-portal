# Booking Portal
The main goal of the project is to practice and review techniques and skills that have already been learned.


![alt text](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/schema.png "Booking application base schema")


## Build Docker Images

#### Booking Portal
```powershell
docker build -f src\WebPortal\Portal\Dockerfile -t <docker hub id>/webportal .
```
#### Supportal 
```powershell
 docker build -f src\Supportal\Portal\Dockerfile -t <docker hub id>/supportal .
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
docker run -p 8070:80 -d <docker hub id>/webportal
```

#### Supportal
```powershell
docker run -p 8060:80 -d <docker hub id>/supportal
```

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
