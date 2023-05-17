﻿using Hotel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure
{
    public static class DataPrePopulation
    {
        private static readonly string[] FirstNames = { "Alice", "Bob", "Charlie", "Dave", "Eve", "Frank", "Grace", "Heidi", "Ivan", "Jack", "Karen", "Larry", "Megan", "Nancy", "Oliver", "Peter", "Quincy", "Rachel", "Samantha", "Trevor", "Ursula", "Victoria", "Walter", "Xavier", "Yvonne", "Zach" };
        private static readonly string[] LastNames = { "Adams", "Brown", "Carter", "Davis", "Edwards", "Franklin", "Garcia", "Hernandez", "Ishikawa", "Johnson", "Klein", "Lee", "Martin", "Nguyen", "O'Connor", "Patel", "Quinn", "Rivera", "Singh", "Thompson", "Ueda", "Valdez", "Williams", "Xiao", "Yamamoto", "Zhang" };
        private static readonly Random Random = new Random();

        private static string GenerateName()
        {
            string firstName = FirstNames[Random.Next(FirstNames.Length)];
            string lastName = LastNames[Random.Next(LastNames.Length)];
            return $"{firstName} {lastName}";
        }

        public static void UseDataPrePopulation(this IApplicationBuilder app)
        {
            using var serciveScope = app.ApplicationServices.CreateScope();
            SeedData(serciveScope.ServiceProvider.GetService<ApplicationDbContext>());
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Set<Models.Hotel>().Any())
            {
                context.Set<Models.Hotel>().AddRange(
                    new Models.Hotel() {
                        Id = Guid.NewGuid(),
                        Name = "Villa Yiara",
                        Address = "Viale Pasitea 294, 84017 Positano, Italy",
                        Country = "Italy",
                        City = "Amalfi",
                        Description = "Featuring a sea-view terrace in each room, Residence Villa Yiara is an adult-only property housed in an 18th-century building. Overlooking the bay of Positano. It offers air-conditioned accommodation 800 m from the beach.<p></p> <p>With white and yellow décor, all rooms at the Villa Yiara residence have free WiFi. Each includes a private bathroom with a shower. Some also feature a spa bath.</p><p>In this lively area of Positano, guests can find restaurants and cafés within walking distance. A 20-minute drive away, the port of Sorrento offers direct links to Ischia and Capri islands. </p>'\r\n\t\t",
                        ReviewScore = 9.6F,
                        MaxPeople = 2,
                        OccupiedDates = new List<HotelOccupiedDate> { 
                            new HotelOccupiedDate(2,GenerateName()),
                            new HotelOccupiedDate(9,GenerateName()),
                            new HotelOccupiedDate(12,GenerateName()),
                            new HotelOccupiedDate(22,GenerateName()),
                            new HotelOccupiedDate(37,GenerateName()),
                            new HotelOccupiedDate(47,GenerateName()),
                            new HotelOccupiedDate(63,GenerateName()),
                            new HotelOccupiedDate(75,GenerateName()),
                            new HotelOccupiedDate(78,GenerateName()),
                            new HotelOccupiedDate(85,GenerateName()),
                            new HotelOccupiedDate(91,GenerateName()),
                            new HotelOccupiedDate(98,GenerateName()),
                            new HotelOccupiedDate(112,GenerateName()),
                            new HotelOccupiedDate(128,GenerateName()),
                            new HotelOccupiedDate(132,GenerateName()),
                            new HotelOccupiedDate(148,GenerateName()),
                            new HotelOccupiedDate(151,GenerateName()),
                            new HotelOccupiedDate(159,GenerateName()),
                            new HotelOccupiedDate(163,GenerateName()),
                            new HotelOccupiedDate(168,GenerateName()),
                            new HotelOccupiedDate(170,GenerateName()),
                            new HotelOccupiedDate(176,GenerateName()),
                            new HotelOccupiedDate(182,GenerateName()),
                            new HotelOccupiedDate(184,GenerateName()),
                            new HotelOccupiedDate(197,GenerateName()),
                            new HotelOccupiedDate(200,GenerateName()),
                            new HotelOccupiedDate(201,GenerateName()),
                            new HotelOccupiedDate(202,GenerateName()),
                            new HotelOccupiedDate(226,GenerateName()),
                            new HotelOccupiedDate(233,GenerateName()),
                            new HotelOccupiedDate(251,GenerateName()),
                            new HotelOccupiedDate(254,GenerateName()),
                            new HotelOccupiedDate(267,GenerateName()),
                            new HotelOccupiedDate(273,GenerateName()),
                            new HotelOccupiedDate(277,GenerateName()),
                            new HotelOccupiedDate(284,GenerateName()),
                            new HotelOccupiedDate(288,GenerateName()),
                            new HotelOccupiedDate(293,GenerateName()),
                            new HotelOccupiedDate(295,GenerateName()),
                            new HotelOccupiedDate(297,GenerateName()),
                            new HotelOccupiedDate(301,GenerateName()),
                            new HotelOccupiedDate(308,GenerateName()),
                            new HotelOccupiedDate(309,GenerateName()),
                            new HotelOccupiedDate(319,GenerateName()),
                            new HotelOccupiedDate(327,GenerateName()),
                            new HotelOccupiedDate(334,GenerateName()),
                            new HotelOccupiedDate(335,GenerateName()),
                            new HotelOccupiedDate(340,GenerateName()),
                            new HotelOccupiedDate(347,GenerateName()),
                            new HotelOccupiedDate(349,GenerateName())
                        },
                        Prices = new List<PeriodPrice> {
                            new PeriodPrice() { Price = 150, FromDay = 91,  ToDay = 180 },
                            new PeriodPrice() { Price = 200, FromDay = 181, ToDay = 270 },
                            new PeriodPrice() { Price = 150, FromDay = 271, ToDay = 335 },
                            new PeriodPrice() { Price = 100, FromDay = 336, ToDay = 90 }
                         },
                        Images = new List<HotelImage>
                         {
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/176045251.jpg?k=cb59f42c3335b4139b845278d6dba22bb0b09a044ac4543c93f839c9be5d4ed8&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/183613358.jpg?k=b8b27b383e76855ee2a5f9438f16879cb0af03366677d1fa453f1b1304bf0a50&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/183613380.jpg?k=0cca09d8a056fd1d0059ea8e75849858e5f538a5527f30be18a4a5e7ac5d0f93&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/183613409.jpg?k=59afe9a1daea85eae9551ad7e7dccde06b35937bc7b01982b000de4558f3229c&o=&hp=1" }
                         } 
                    },
                    new Models.Hotel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Alcione Residence",
                        Address = "Via C. Colombo 135, 84017 Positano, Italy",
                        Country = "Italy",
                        City = "Amalfi",
                        Description = "<p>You're eligible for a Genius discount at Alcione Residence! To save at this property, all you have to do is sign in.</p> <p></p> High above the Tyrrhenian Sea, the Alcione is set in Positano center, 37 mi from Naples-Capodichino Airport. This residence features Mediterranean style rooms, each with a private panoramic terrace.<p></p> <p>The Alcione Residence's rooms are spacious and bright, with tiled floors and individual bathroom. All rooms include a flat-screen TV with satellite channels and tea/coffee ingredients.</p> <p>When booking a room, the residence offers a sweet breakfast featuring home-made cakes, served on the guests' own balcony. Savory options are on request.</p> <p>Located in a pedestrian zone, Alcione is a 10-minute walk from the beach. Private parking is available nearby. </p>",
                        ReviewScore = 9.4F,
                        MaxPeople = 4,
                        OccupiedDates = new List<HotelOccupiedDate> {
                            new HotelOccupiedDate(2,GenerateName()),
                            new HotelOccupiedDate(9,GenerateName()),
                            new HotelOccupiedDate(12,GenerateName()),
                            new HotelOccupiedDate(22,GenerateName()),
                            new HotelOccupiedDate(37,GenerateName()),
                            new HotelOccupiedDate(47,GenerateName()),
                            new HotelOccupiedDate(63,GenerateName()),
                            new HotelOccupiedDate(75,GenerateName()),
                            new HotelOccupiedDate(78,GenerateName()),
                            new HotelOccupiedDate(85,GenerateName()),
                            new HotelOccupiedDate(91,GenerateName()),
                            new HotelOccupiedDate(98,GenerateName()),
                            new HotelOccupiedDate(112,GenerateName()),
                            new HotelOccupiedDate(128,GenerateName()),
                            new HotelOccupiedDate(132,GenerateName()),
                            new HotelOccupiedDate(148,GenerateName()),
                            new HotelOccupiedDate(151,GenerateName()),
                            new HotelOccupiedDate(159,GenerateName()),
                            new HotelOccupiedDate(163,GenerateName()),
                            new HotelOccupiedDate(168,GenerateName()),
                            new HotelOccupiedDate(170,GenerateName()),
                            new HotelOccupiedDate(176,GenerateName()),
                            new HotelOccupiedDate(182,GenerateName()),
                            new HotelOccupiedDate(184,GenerateName()),
                            new HotelOccupiedDate(197,GenerateName()),
                            new HotelOccupiedDate(200,GenerateName()),
                            new HotelOccupiedDate(201,GenerateName()),
                            new HotelOccupiedDate(202,GenerateName()),
                            new HotelOccupiedDate(226,GenerateName()),
                            new HotelOccupiedDate(233,GenerateName()),
                            new HotelOccupiedDate(251,GenerateName()),
                            new HotelOccupiedDate(254,GenerateName()),
                            new HotelOccupiedDate(267,GenerateName()),
                            new HotelOccupiedDate(273,GenerateName()),
                            new HotelOccupiedDate(277,GenerateName()),
                            new HotelOccupiedDate(284,GenerateName()),
                            new HotelOccupiedDate(288,GenerateName()),
                            new HotelOccupiedDate(293,GenerateName()),
                            new HotelOccupiedDate(295,GenerateName()),
                            new HotelOccupiedDate(297,GenerateName()),
                            new HotelOccupiedDate(301,GenerateName()),
                            new HotelOccupiedDate(308,GenerateName()),
                            new HotelOccupiedDate(309,GenerateName()),
                            new HotelOccupiedDate(319,GenerateName()),
                            new HotelOccupiedDate(327,GenerateName()),
                            new HotelOccupiedDate(334,GenerateName()),
                            new HotelOccupiedDate(335,GenerateName()),
                            new HotelOccupiedDate(340,GenerateName()),
                            new HotelOccupiedDate(347,GenerateName()),
                            new HotelOccupiedDate(349,GenerateName())
                        },
                        Prices = new List<PeriodPrice> {
                            new PeriodPrice() { Price = 150, FromDay = 91,  ToDay = 180 },
                            new PeriodPrice() { Price = 200, FromDay = 181, ToDay = 270 },
                            new PeriodPrice() { Price = 150, FromDay = 271, ToDay = 335 },
                            new PeriodPrice() { Price = 100, FromDay = 336, ToDay = 90 }
                         },
                        Images = new List<HotelImage>
                         {
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/322686548.jpg?k=ff1fecdcc65f0d395e17538d3ca01140b868debfa1f09173efa55b8c353717f1&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/149738954.jpg?k=415fb749ada8e13f80a1399700d9be09dfaf782d906258cb178577f2cc0ceb58&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/223282433.jpg?k=63a4a9d5b006fd52989fe8536a722af1cf1efb7d607be0c010b37407219da435&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/149738616.jpg?k=a0200efa9f5d6e64d82d3318dba240b8fd35b0fded4b5451f8c4dd47fcb6a47d&o=&hp=1" }
                         }
                    },
                    new Models.Hotel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Hotel Villa Bellavista",
                        Address = "Via Rezzola 47, 84010 Praiano, Italy",
                        Country = "Italy",
                        City = "Amalfi",
                        Description = "<p>You're eligible for a Genius discount at Hotel Villa Bellavista! To save at this property, all you have to do is sign in</a>.</p> <p></p> The family-run Hotel Villa Bellavista is located in Praiano, an ancient fisherman's village near Positano and Amalfi. The bus running along the coast stops nearby. A bar and a restaurant are also available.<p></p> <p>Rooms are provided with air conditioning and a TV, and most offer a balcony with sea views. The rooms are decorated in the style characteristic of the Amalfi area.</p> <p>Villa Bellavista is surrounded by lemon trees and olive groves, in a tranquil, panoramic position off the main road. The large terrace offers views of the bay, including Capri Island.</p> <p>The restaurant specializes in local cuisine. Dinner and continental breakfast can be enjoyed on the terrace, weather permitting.</p> <p>If you wish to visit Capri and the Emerald Cave, the hotel can arrange cruises on its private boat. The starting point of the Path of the Gods is a 5-minute walk away. </p>",
                        ReviewScore = 8.2F,
                        MaxPeople = 4,
                        OccupiedDates = new List<HotelOccupiedDate> {
                            new HotelOccupiedDate(2,GenerateName()),
                            new HotelOccupiedDate(9,GenerateName()),
                            new HotelOccupiedDate(12,GenerateName()),
                            new HotelOccupiedDate(22,GenerateName()),
                            new HotelOccupiedDate(37,GenerateName()),
                            new HotelOccupiedDate(47,GenerateName()),
                            new HotelOccupiedDate(63,GenerateName()),
                            new HotelOccupiedDate(75,GenerateName()),
                            new HotelOccupiedDate(78,GenerateName()),
                            new HotelOccupiedDate(85,GenerateName()),
                            new HotelOccupiedDate(91,GenerateName()),
                            new HotelOccupiedDate(98,GenerateName()),
                            new HotelOccupiedDate(112,GenerateName()),
                            new HotelOccupiedDate(128,GenerateName()),
                            new HotelOccupiedDate(132,GenerateName()),
                            new HotelOccupiedDate(148,GenerateName()),
                            new HotelOccupiedDate(151,GenerateName()),
                            new HotelOccupiedDate(159,GenerateName()),
                            new HotelOccupiedDate(163,GenerateName()),
                            new HotelOccupiedDate(168,GenerateName()),
                            new HotelOccupiedDate(170,GenerateName()),
                            new HotelOccupiedDate(176,GenerateName()),
                            new HotelOccupiedDate(182,GenerateName()),
                            new HotelOccupiedDate(184,GenerateName()),
                            new HotelOccupiedDate(197,GenerateName()),
                            new HotelOccupiedDate(200,GenerateName()),
                            new HotelOccupiedDate(201,GenerateName()),
                            new HotelOccupiedDate(202,GenerateName()),
                            new HotelOccupiedDate(226,GenerateName()),
                            new HotelOccupiedDate(233,GenerateName()),
                            new HotelOccupiedDate(251,GenerateName()),
                            new HotelOccupiedDate(254,GenerateName()),
                            new HotelOccupiedDate(267,GenerateName()),
                            new HotelOccupiedDate(273,GenerateName()),
                            new HotelOccupiedDate(277,GenerateName()),
                            new HotelOccupiedDate(284,GenerateName()),
                            new HotelOccupiedDate(288,GenerateName()),
                            new HotelOccupiedDate(293,GenerateName()),
                            new HotelOccupiedDate(295,GenerateName()),
                            new HotelOccupiedDate(297,GenerateName()),
                            new HotelOccupiedDate(301,GenerateName()),
                            new HotelOccupiedDate(308,GenerateName()),
                            new HotelOccupiedDate(309,GenerateName()),
                            new HotelOccupiedDate(319,GenerateName()),
                            new HotelOccupiedDate(327,GenerateName()),
                            new HotelOccupiedDate(334,GenerateName()),
                            new HotelOccupiedDate(335,GenerateName()),
                            new HotelOccupiedDate(340,GenerateName()),
                            new HotelOccupiedDate(347,GenerateName()),
                            new HotelOccupiedDate(349,GenerateName())
                        },
                        Prices = new List<PeriodPrice> {
                            new PeriodPrice() { Price = 150, FromDay = 91,  ToDay = 180 },
                            new PeriodPrice() { Price = 200, FromDay = 181, ToDay = 270 },
                            new PeriodPrice() { Price = 150, FromDay = 271, ToDay = 335 },
                            new PeriodPrice() { Price = 100, FromDay = 336, ToDay = 90 }
                         },
                        Images = new List<HotelImage>
                         {
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/232396480.jpg?k=7d70395e731f26d561e5f15097127abf663e066ec6228eea2c365e493f19a095&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/232393456.jpg?k=883addace463c01a624670aed3c756471bbd6514adc2dc1592ca6e21bbc4c7ef&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/232395755.jpg?k=bf2bed2bb04271542a678d028661534661487e06382dd1d78b8c6acf847bf8c7&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/172161697.jpg?k=48d1b6c37147101023b7c77f6ea3a43c9fcfb7942ac27499c18c188d08eff684&o=&hp=1" }
                         }
                    },
                    new Models.Hotel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Vista d' Amalfi",
                        Address = "Via Matteo Camera 17, 84011 Amalfi, Italy ",
                        Country = "Italy",
                        City = "Amalfi",
                        Description = "Vista d'Amalfi offers air-conditioned rooms with sea view and free WiFi in Amalfi, 200 m from the city center and a short walk from the ferry terminal to Capri.<p></p><p>All rooms feature a flat-screen TV with satellite channels, and a private bathroom fitted with a shower and a hairdryer. Featuring a balcony or a terrace, each room also comes with a desk, a kettle and a coffee machine.</p><p>A buffet breakfast is available daily at the property.</p><p>Naples is 39 mi from Vista d'Amalfi. The nearest airport is Naples International Airport, 40 mi away. </p>",
                        ReviewScore = 8.7F,
                        MaxPeople = 4,
                        OccupiedDates = new List<HotelOccupiedDate> {
                            new HotelOccupiedDate(2,GenerateName()),
                            new HotelOccupiedDate(9,GenerateName()),
                            new HotelOccupiedDate(12,GenerateName()),
                            new HotelOccupiedDate(22,GenerateName()),
                            new HotelOccupiedDate(37,GenerateName()),
                            new HotelOccupiedDate(47,GenerateName()),
                            new HotelOccupiedDate(63,GenerateName()),
                            new HotelOccupiedDate(75,GenerateName()),
                            new HotelOccupiedDate(78,GenerateName()),
                            new HotelOccupiedDate(85,GenerateName()),
                            new HotelOccupiedDate(91,GenerateName()),
                            new HotelOccupiedDate(98,GenerateName()),
                            new HotelOccupiedDate(112,GenerateName()),
                            new HotelOccupiedDate(128,GenerateName()),
                            new HotelOccupiedDate(132,GenerateName()),
                            new HotelOccupiedDate(148,GenerateName()),
                            new HotelOccupiedDate(151,GenerateName()),
                            new HotelOccupiedDate(159,GenerateName()),
                            new HotelOccupiedDate(163,GenerateName()),
                            new HotelOccupiedDate(168,GenerateName()),
                            new HotelOccupiedDate(170,GenerateName()),
                            new HotelOccupiedDate(176,GenerateName()),
                            new HotelOccupiedDate(182,GenerateName()),
                            new HotelOccupiedDate(184,GenerateName()),
                            new HotelOccupiedDate(197,GenerateName()),
                            new HotelOccupiedDate(200,GenerateName()),
                            new HotelOccupiedDate(201,GenerateName()),
                            new HotelOccupiedDate(202,GenerateName()),
                            new HotelOccupiedDate(226,GenerateName()),
                            new HotelOccupiedDate(233,GenerateName()),
                            new HotelOccupiedDate(251,GenerateName()),
                            new HotelOccupiedDate(254,GenerateName()),
                            new HotelOccupiedDate(267,GenerateName()),
                            new HotelOccupiedDate(273,GenerateName()),
                            new HotelOccupiedDate(277,GenerateName()),
                            new HotelOccupiedDate(284,GenerateName()),
                            new HotelOccupiedDate(288,GenerateName()),
                            new HotelOccupiedDate(293,GenerateName()),
                            new HotelOccupiedDate(295,GenerateName()),
                            new HotelOccupiedDate(297,GenerateName()),
                            new HotelOccupiedDate(301,GenerateName()),
                            new HotelOccupiedDate(308,GenerateName()),
                            new HotelOccupiedDate(309,GenerateName()),
                            new HotelOccupiedDate(319,GenerateName()),
                            new HotelOccupiedDate(327,GenerateName()),
                            new HotelOccupiedDate(334,GenerateName()),
                            new HotelOccupiedDate(335,GenerateName()),
                            new HotelOccupiedDate(340,GenerateName()),
                            new HotelOccupiedDate(347,GenerateName()),
                            new HotelOccupiedDate(349,GenerateName())
                        },
                        Prices = new List<PeriodPrice> {
                            new PeriodPrice() { Price = 150, FromDay = 91,  ToDay = 180 },
                            new PeriodPrice() { Price = 200, FromDay = 181, ToDay = 270 },
                            new PeriodPrice() { Price = 150, FromDay = 271, ToDay = 335 },
                            new PeriodPrice() { Price = 100, FromDay = 336, ToDay = 90 }
                         },
                        Images = new List<HotelImage>
                         {
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/100378456.jpg?k=30ea8dfe6c837dc10ff0fa87b9428f026e78664fd21c489e16826bb91f80441f&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/100378467.jpg?k=46715a317a3e743165179c745cbddb8088c358fb29c1141701ce474f13035e6c&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/100378395.jpg?k=8065aeea2098151cb165cdd9ece1322b4a52f78c81126530d06e9ed7d34adcdc&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/100378381.jpg?k=5af053b15e792c98fd6ba761844ff392c6a095b7a7e35d0255555c0d2ea7920c&o=&hp=1" }
                         }
                    },
                    new Models.Hotel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Aquaboutique Wellness&Spa",
                        Address = "Via Costiera Amalfitana 44, 84019 Vietri sul Mare, Italy ",
                        Country= "Italy",
                        City = "Amalfi",
                        Description = "Located in Vietri sul Mare, a 2-minute walk from Spiaggia dello Scoglione, Aquaboutique Wellness&amp;Spa has accommodations with a shared lounge, free private parking and a terrace. Among the facilities at this property are room service and a concierge service, along with free WiFi throughout the property. Guests can enjoy city views.<p></p><p>The guesthouse will provide guests with air-conditioned rooms offering a desk, an electric tea pot, a minibar, a safety deposit box, a flat-screen TV and a private bathroom with a bidet. All rooms feature a closet.</p><p>A buffet, American or gluten-free breakfast is available every morning at the property.</p><p>Popular points of interest near Aquaboutique Wellness&amp;Spa include Spiaggia della Torre di Albori, Spiaggia della Carrubina and Marina di Vietri Beach. </p>",
                        ReviewScore = 9.0F,
                        MaxPeople = 4,
                        OccupiedDates = new List<HotelOccupiedDate> {
                            new HotelOccupiedDate(2,GenerateName()),
                            new HotelOccupiedDate(9,GenerateName()),
                            new HotelOccupiedDate(12,GenerateName()),
                            new HotelOccupiedDate(22,GenerateName()),
                            new HotelOccupiedDate(37,GenerateName()),
                            new HotelOccupiedDate(47,GenerateName()),
                            new HotelOccupiedDate(63,GenerateName()),
                            new HotelOccupiedDate(75,GenerateName()),
                            new HotelOccupiedDate(78,GenerateName()),
                            new HotelOccupiedDate(85,GenerateName()),
                            new HotelOccupiedDate(91,GenerateName()),
                            new HotelOccupiedDate(98,GenerateName()),
                            new HotelOccupiedDate(112,GenerateName()),
                            new HotelOccupiedDate(128,GenerateName()),
                            new HotelOccupiedDate(132,GenerateName()),
                            new HotelOccupiedDate(148,GenerateName()),
                            new HotelOccupiedDate(151,GenerateName()),
                            new HotelOccupiedDate(159,GenerateName()),
                            new HotelOccupiedDate(163,GenerateName()),
                            new HotelOccupiedDate(168,GenerateName()),
                            new HotelOccupiedDate(170,GenerateName()),
                            new HotelOccupiedDate(176,GenerateName()),
                            new HotelOccupiedDate(182,GenerateName()),
                            new HotelOccupiedDate(184,GenerateName()),
                            new HotelOccupiedDate(197,GenerateName()),
                            new HotelOccupiedDate(200,GenerateName()),
                            new HotelOccupiedDate(201,GenerateName()),
                            new HotelOccupiedDate(202,GenerateName()),
                            new HotelOccupiedDate(226,GenerateName()),
                            new HotelOccupiedDate(233,GenerateName()),
                            new HotelOccupiedDate(251,GenerateName()),
                            new HotelOccupiedDate(254,GenerateName()),
                            new HotelOccupiedDate(267,GenerateName()),
                            new HotelOccupiedDate(273,GenerateName()),
                            new HotelOccupiedDate(277,GenerateName()),
                            new HotelOccupiedDate(284,GenerateName()),
                            new HotelOccupiedDate(288,GenerateName()),
                            new HotelOccupiedDate(293,GenerateName()),
                            new HotelOccupiedDate(295,GenerateName()),
                            new HotelOccupiedDate(297,GenerateName()),
                            new HotelOccupiedDate(301,GenerateName()),
                            new HotelOccupiedDate(308,GenerateName()),
                            new HotelOccupiedDate(309,GenerateName()),
                            new HotelOccupiedDate(319,GenerateName()),
                            new HotelOccupiedDate(327,GenerateName()),
                            new HotelOccupiedDate(334,GenerateName()),
                            new HotelOccupiedDate(335,GenerateName()),
                            new HotelOccupiedDate(340,GenerateName()),
                            new HotelOccupiedDate(347,GenerateName()),
                            new HotelOccupiedDate(349,GenerateName())
                        },
                        Prices = new List<PeriodPrice> {
                            new PeriodPrice() { Price = 150, FromDay = 91,  ToDay = 180 },
                            new PeriodPrice() { Price = 200, FromDay = 181, ToDay = 270 },
                            new PeriodPrice() { Price = 150, FromDay = 271, ToDay = 335 },
                            new PeriodPrice() { Price = 100, FromDay = 336, ToDay = 90 }
                         },
                        Images = new List<HotelImage>
                         {
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/203746747.jpg?k=22c161c202591cd8b579763e908b37067525049c4f2d702d1efd5f231f201c34&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/412635930.jpg?k=71894514b88b74542d6209b31212cb7022fcee88fb090b3b408a0768af6bd043&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/412834328.jpg?k=cccb66bc692c84bc7a9d39f611f6f052ed5018c697a7596027d6f1a168729f47&o=&hp=1" },
                            new HotelImage{ ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/203734471.jpg?k=06d1c7bf22561db6ad38dfcfc23f2431d6c0f436703234f3eeba2f512e0083a0&o=&hp=1" }
                         }
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
