using CarRent.Application;
using CarRent.Application.Interfaces;
using CarRent.Models;
using FluentAssertions;
using Moq;
using Serilog;

namespace AppplicationTests
{
    public class DistanceCalculatorTests
    {
        private IDistanceCalculator _distanceCalculator;

        [SetUp]
        public void Setup()
        {
            var cageClientMock = new Mock<IOpenCageDataClient>();

            cageClientMock.Setup(client => client.GetLocationByName(It.IsAny<string>()))
                .Returns(( 40.8863637540212,14.288939376033577 ));

            _distanceCalculator = new DistanceCalculator( cageClientMock.Object);
        }

        /// <summary>
        /// This test is checking proper working of Haversine formula  
        /// and compare results with https://www.nhc.noaa.gov/gccalc.shtml calculator.
        /// In test user tree location : Colosseum of Rome, Istanbul Airport, Warsaw Chopin Airport.
        /// </summary>
        [TestCase(41.89238570901066, 12.492829558712781, 187)]
        [TestCase(41.2766543782809, 28.72962032918603, 1210)] 
        [TestCase(52.165013300221524, 20.969376731611778, 1353)] 
        public void Test1(double lat, double lon, int result)
        {
            var actualResult = _distanceCalculator.CalculateDistance(new Location { Latitude = lat, Longitude = lon }, "Aeroporto Internazionale di Napoli");
            Math.Round(actualResult, MidpointRounding.AwayFromZero).Should().Be(result);
        }
    }
}