using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Helpers
{
    public static class GenerateRandomData
    {
        private static readonly string[] FirstNames = { "Alice", "Bob", "Charlie", "Dave", "Eve", "Frank", "Grace", "Heidi", "Ivan", "Jack", "Karen", "Larry", "Megan", "Nancy", "Oliver", "Peter", "Quincy", "Rachel", "Samantha", "Trevor", "Ursula", "Victoria", "Walter", "Xavier", "Yvonne", "Zach" };
        private static readonly string[] LastNames = { "Adams", "Brown", "Carter", "Davis", "Edwards", "Franklin", "Garcia", "Hernandez", "Ishikawa", "Johnson", "Klein", "Lee", "Martin", "Nguyen", "O'Connor", "Patel", "Quinn", "Rivera", "Singh", "Thompson", "Ueda", "Valdez", "Williams", "Xiao", "Yamamoto", "Zhang" };
        private static readonly Random Random = new Random();

        public static string GenerateName()
        {
            string firstName = FirstNames[Random.Next(FirstNames.Length)];
            string lastName = LastNames[Random.Next(LastNames.Length)];
            return $"{firstName} {lastName}";
        }

    }
}
