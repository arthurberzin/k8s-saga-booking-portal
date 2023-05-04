using CarRent.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarRent.Infrastructure
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
            if (!context.Set<Car>().Any())
            {
                context.Set<Car>().AddRange(
                    new Car
                    {
                        CurrentLocation = new Location { 
                            Latitude = 40.847261979137436,
                            Longitude = 14.312058323004266
                        },
                        Name = "Dacia Logan MCV",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/dacia/logan_mcv_lrg.jpg",
                        Type = CarType.Estate,
                        Transmission = TransmissionType.Automatic,
                        Seats = 5,
                        LargeBag = 3,
                        SmallBag = 2,
                        MileageLimit =0, 
                        PricePerDay =50
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.888928234509,
                            Longitude = 14.309043494843904
                        },
                        Name = "Citroen C3",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/citroen/c3_lrg.jpg",
                        Type = CarType.Small,
                        Transmission = TransmissionType.Manual,
                        Seats = 5,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 45
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.919851840520295,
                            Longitude = 14.218619483625968,
                        },
                        Name = "Volkswagen Polo",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/volkswagen/polo_lrg.jpg",
                        Type = CarType.Small,
                        Transmission = TransmissionType.Automatic,
                        Seats = 5,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 70
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.902552950411554,
                            Longitude = 14.228190983116145
                        },
                        Name = "Kia Picanto",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/kia/picanto_lrg.jpg",
                        Type = CarType.Small,
                        Transmission = TransmissionType.Manual,
                        Seats = 4,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 70
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.84374487548638,                            
                            Longitude = 14.116159666387542,
                        },
                        Name = "Fiat 500X",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/fiat/500x_lrg.jpg",
                        Type = CarType.Medium,
                        Transmission = TransmissionType.Automatic,
                        Seats = 5,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 75
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.86842099315672,
                            Longitude = 14.350070565550771,
                        },
                        Name = "Opel Corsa",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/opel/corsa_lrg.jpg",
                        Type = CarType.Small,
                        Transmission = TransmissionType.Manual,
                        Seats = 5,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 55
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.8972331571794,                            
                            Longitude = 14.273681249799491,
                        },
                        Name = "Ford Fiesta",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/ford/fiesta_lrg.jpg",
                        Type = CarType.Small,
                        Transmission = TransmissionType.Automatic,
                        Seats = 5,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 80
                    },
                    new Car
                    {
                        CurrentLocation = new Location
                        {
                            Latitude = 40.88075205808668,                            
                            Longitude = 14.404487224187077,
                        },
                        Name = "Fiat 500L",
                        ImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/fiat/500l_lrg.jpg",
                        Type = CarType.Medium,
                        Transmission = TransmissionType.Manual,
                        Seats = 5,
                        LargeBag = 1,
                        SmallBag = 1,
                        MileageLimit = 0,
                        PricePerDay = 75
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
