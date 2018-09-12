namespace FizzBuzz
{
    using System.Collections.Generic;
    using Xunit;

    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(20, "Buzz")]
        [InlineData(30, "FizzBuzz")]
        [InlineData(45, "FizzBuzz")]
        public void FizzBuzzTest(int number, string expectedOutput)
        {
            var rules = new List<IRule>
            {
                new FizzRule(),
                new BuzzRule()
            };

            Assert.Equal(expectedOutput, FizzBuzz(number, rules));
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(15, "BuzzFizz")]
        [InlineData(20, "Buzz")]
        [InlineData(30, "BuzzFizz")]
        [InlineData(45, "BuzzFizz")]
        public void BuzzFizzTest(int number, string expectedOutput)
        {
            var rules = new List<IRule>
            {
                new BuzzRule(),
                new FizzRule()
            };

            Assert.Equal(expectedOutput, FizzBuzz(number, rules));
        }

        private string FizzBuzz(int value, List<IRule> rules)
        {
            var output = string.Empty;

            foreach (var rule in rules)
            {
                output += rule.Value(value);
            }

            if (NotASpecialValue(output))
            {
                output = value.ToString();
            }

            return output;
        }

        private static bool NotASpecialValue(string returnValue)
        {
            return string.IsNullOrEmpty(returnValue);
        }
    }
}
