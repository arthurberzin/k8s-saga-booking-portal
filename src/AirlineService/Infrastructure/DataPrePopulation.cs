using Airline.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Airline.Infrastructure
{
    public static class DataPrePopulation
    {
        public static void UseDataPrePopulation(this IApplicationBuilder app)
        {
            using var serciveScope = app.ApplicationServices.CreateScope();
            SeedData(serciveScope.ServiceProvider.GetService<ApplicationDbContext>());
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Set<Flight>().Any())
            {

                #region Crew
                Employee emilySmith = new Employee
                {
                    FirstName = "Emily",
                    LastName = "Smith",
                    HireDate = DateTime.UtcNow.AddDays(-600),
                    Position = new EmployeePosition
                    {
                        Title = PositionTitle.AirlineSteward_Stewardess,
                        EndDate = null,
                        Salary = 1500,
                        StartDate = DateTime.UtcNow.AddDays(-600),
                        Department = DepartmentType.InFlightServicesDepartment
                    }
                };

                CrewAssignment emilyCrewAssignment = new CrewAssignment
                {
                    Employee = emilySmith,
                    Role = CrewRole.FlightAttendant,
                };

                Employee emmaJohnson = new Employee
                {
                    FirstName = "Emma",
                    LastName = "Johnson",
                    HireDate = DateTime.UtcNow.AddDays(-500),
                    Position = new EmployeePosition
                    {
                        Title = PositionTitle.AirlineAttendant,
                        EndDate = null,
                        Salary = 1300,
                        StartDate = DateTime.UtcNow.AddDays(-500),
                        Department = DepartmentType.InFlightServicesDepartment
                    }
                };

                CrewAssignment emmaCrewAssignment = new CrewAssignment
                {
                    Employee = emmaJohnson,
                    Role = CrewRole.FlightAttendant,
                };

                Employee sophiaRodriguez = new Employee
                {
                    FirstName = "Sophia",
                    LastName = "Rodriguez",
                    HireDate = DateTime.UtcNow.AddDays(-900),
                    Position = new EmployeePosition
                    {
                        Title = PositionTitle.FlightAttendant_InFlightSupervisor,
                        EndDate = null,
                        Salary = 1900,
                        StartDate = DateTime.UtcNow.AddDays(-900),
                        Department = DepartmentType.InFlightServicesDepartment
                    }
                };

                CrewAssignment sophiaCrewAssignment = new CrewAssignment
                {
                    Employee = sophiaRodriguez,
                    Role = CrewRole.FlightAttendant,
                };

                Employee noahJohnson = new Employee
                {
                    FirstName = "Noah",
                    LastName = "Johnson",
                    HireDate = DateTime.UtcNow.AddDays(-1200),
                    Position = new EmployeePosition
                    {
                        Title = PositionTitle.CommercialPilot,
                        EndDate = null,
                        Salary = 3000,
                        StartDate = DateTime.UtcNow.AddDays(-1200),
                        Department = DepartmentType.FlightOperationsDepartment
                    }
                };

                CrewAssignment noahCrewAssignment = new CrewAssignment
                {
                    Employee = noahJohnson,
                    Role = CrewRole.CoPilot,
                };

                Employee benjaminLee = new Employee
                {
                    FirstName = "Benjamin",
                    LastName = "Lee",
                    HireDate = DateTime.UtcNow.AddDays(-1500),
                    Position = new EmployeePosition
                    {
                        Title = PositionTitle.Pilot,
                        EndDate = null,
                        Salary = 3500,
                        StartDate = DateTime.UtcNow.AddDays(-1500),
                        Department = DepartmentType.FlightOperationsDepartment
                    }
                };

                CrewAssignment benjaminCrewAssignment = new CrewAssignment
                {
                    Employee = benjaminLee,
                    Role = CrewRole.Pilot,
                };
                #endregion

                #region Airport
                Airport warsawAirport = new Airport
                {
                    AirportCode = "WAW",
                    AirportName = "Warsaw Airport",
                    City = "Warsaw",
                    Country = "Poland",
                    State = "MZ"
                };

                Airport napoliAirport = new Airport
                {
                    AirportCode = "NAP",
                    AirportName = "Napoli Airport",
                    City = "Napoli",
                    Country = "Italy",
                    State = "72"
                };
                #endregion

                #region Aircraft
                Aircraft aircraftSPLPD = new Aircraft
                {
                    AircraftType = AircraftType.Boeing747,
                    Capacity = 80,
                    RegistrationNumber = "SP-LPD",
                };
                #endregion

                #region Flight
                Flight flightW6245_WarsawNaples = new Flight
                {
                    Crew = new List<CrewAssignment> {
                        emilyCrewAssignment,
                        emmaCrewAssignment ,
                        sophiaCrewAssignment,
                        noahCrewAssignment,
                        benjaminCrewAssignment
                    },
                    FlightNumber = "W6245",
                    SeatPrice = 150,
                    DepartureAirport = warsawAirport,
                    ArrivalAirport = napoliAirport,
                    DepartureDateTime = DateTime.UtcNow.AddDays(100).AddHours(10),
                    ArrivalDateTime = DateTime.UtcNow.AddDays(100).AddHours(14),
                    Aircraft = aircraftSPLPD,
                    SeatsBookings =

                    new List<Seat> {
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-10),
                                PassengerName = "Liam Smith"
                            },
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-20),
                                PassengerName = "Madison Brown"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-14),
                                PassengerName = "Olivia Davis"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 140,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-22),
                                PassengerName = "Ava Garcia"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-15),
                                PassengerName = "Sophia Rodriguez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-17),
                                PassengerName = "Isabella Martinez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 140,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-25),
                                PassengerName = "Mia Hernandez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 120,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-42),
                                PassengerName = "Charlotte Gonzalez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 140,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-22),
                                PassengerName = "Amelia Perez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-20),
                                PassengerName = "Michael Garcia"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-6),
                                PassengerName = "Liam Smith"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 140,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-23),
                                PassengerName = "William Brown"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 130,
                            Booking = new Booking{
                            BookingDateTime = DateTime.UtcNow.AddDays(-27),
                            PassengerName = "Ethan Davis"
                        }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-12),
                                PassengerName = "Oliver Rodriguez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-2),
                                PassengerName = "James Martinez"
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 150,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-4),
                                PassengerName = "Lucas Hernandez",
                            }
                        },
                        new Seat {
                            SeatNumber = String.Empty,
                            Price = 120,
                            Booking = new Booking{
                                BookingDateTime = DateTime.UtcNow.AddDays(-31),
                                PassengerName = "Mason Jones"
                            }
                        },
                    }
                };

                #endregion

                context.Set<Flight>().AddRange(
                    flightW6245_WarsawNaples
                );

                context.SaveChanges();
            }
        }
    }
}
