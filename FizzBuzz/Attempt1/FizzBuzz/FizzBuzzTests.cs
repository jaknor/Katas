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
            var returnValue = string.Empty;

            if (value % 3 == 0)
            {
                returnValue += "Fizz";
            }

            if (value % 5 == 0)
            {
                returnValue += "Buzz";
            }

            if (string.IsNullOrEmpty(returnValue))
            {
                return value.ToString();
            }

            return returnValue;
        }
    }
}
