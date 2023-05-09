

# Airlines Database Schema

![alt text](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/dbschema.png "Airlines Database Schema")



## Entities

 - [Aircraft](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/Aircraft.cs)
 - [Airport](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/Airport.cs)
 - [Booking](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/Booking.cs)
 - [CrewAssignment](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/CrewAssignment.cs)
 - [Employee](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/Employee.cs)
 - [EmployeePosition](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/EmployeePosition.cs)
 - [Flight](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/Flight.cs)
 - [Seat](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineModels/Seat.cs)

 ## DB Context

 - [ApplicationDbContext](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/ApplicationDbContext.cs)
 - [DependencyInjection](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/DependencyInjection.cs)

 ## Entities Configuration
 
 - [Aircraft Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/AircraftConfiguration.cs)
 - [Airport Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/AirportConfiguration.cs)
 - [Booking Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/BookingConfiguration.cs)
 - [CrewC onfiguration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/CrewConfiguration.cs)
 - [Employee Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/EmployeeConfiguration.cs)
 - [Employee Position Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/EmployeePositionConfiguration.cs)
 - [Flight Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/FlightConfiguration.cs)
 - [Seat Configuration](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Config/SeatConfiguration.cs)

 ## Unit Of Work with Repository pattern

 - [UnitOfWork](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/UnitOfWork.cs)
 - [IUnitOfWork](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineApplication/Interfaces/IUnitOfWork.cs)
  
 - [IRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/AirlineApplication/Interfaces/IRepository.cs)
 - [Repository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/Repository.cs)

 - [AircraftRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/AircraftRepository.cs)
 - [AirportRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/AirportRepository.cs)
 - [BookingRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/BookingRepository.cs)
 - [CrewRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/CrewRepository.cs)
 - [EmployeePositionRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/EmployeePositionRepository.cs)
 - [EmployeeRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/EmployeeRepository.cs)
 - [FlightRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/FlightRepository.cs) 
 - [SeatRepository](https://github.com/arthurberzin/k8s-saga-booking-portal/blob/main/src/AirlineService/Infrastructure/Context/SeatRepository.cs) 