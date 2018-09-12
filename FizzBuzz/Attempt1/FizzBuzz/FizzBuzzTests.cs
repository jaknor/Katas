namespace FizzBuzz
{
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
        public void Tests(int number, string expectedOutput)
        {
            Assert.Equal(expectedOutput, FizzBuzz(number));
        }

        private string FizzBuzz(int value)
        {
            var output = string.Empty;

            if (FizzValue(value))
            {
                output += "Fizz";
            }

            if (BuzzValue(value))
            {
                output += "Buzz";
            }

            if (NotFizzOrBuzzValue(output))
            {
                output = value.ToString();
            }

            return output;
        }

        private static bool FizzValue(int value)
        {
            return value % 3 == 0;
        }

        private static bool BuzzValue(int value)
        {
            return value % 5 == 0;
        }

        private static bool NotFizzOrBuzzValue(string returnValue)
        {
            return string.IsNullOrEmpty(returnValue);
        }
    }
}
