using Core.Common;
using FluentAssertions;
using NUnit.Framework;

namespace CommonTests
{
    public class EnumHelperTests
    {
        public enum CoffeType
        {            
            Ristretto = 0,

            [System.ComponentModel.Description("Espresso")]
            Espresso = 1,

            [System.ComponentModel.Description("Americano")]
            Americano = 2,

            [System.ComponentModel.Description("Cappuccino")]
            Cappuccino = 3,

            [System.ComponentModel.Description("Latte")]
            Latte = 4,

            [System.ComponentModel.Description("Mocha")]
            Mocha = 5
        }

        [TestCase("Espresso",CoffeType.Espresso)]
        [TestCase("Americano", CoffeType.Americano)]
        [TestCase("Cappuccino", CoffeType.Cappuccino)]
        [TestCase("Latte", CoffeType.Latte)]
        [TestCase("Mocha", CoffeType.Mocha)]
        [TestCase("Ristretto", CoffeType.Ristretto)]
        [TestCase("badDescription", CoffeType.Ristretto)]
        [TestCase("", CoffeType.Ristretto)]
        [TestCase(null, CoffeType.Ristretto)]
        public void EnumDescriptionParse(string value, CoffeType result)
        {
            EnumHelper.GetValueFromDescription<CoffeType>(value).Should().Be(result);
        }

        [TestCase( CoffeType.Espresso, "Espresso")]
        [TestCase( CoffeType.Americano, "Americano")]
        [TestCase( CoffeType.Cappuccino, "Cappuccino")]
        [TestCase(CoffeType.Latte, "Latte")]
        [TestCase( CoffeType.Mocha, "Mocha")]
        [TestCase( CoffeType.Ristretto, "")]
        public void GetDescription(CoffeType value, string result)
        {
            value.GetDescription().Should().Be(result);
        }
    }
}