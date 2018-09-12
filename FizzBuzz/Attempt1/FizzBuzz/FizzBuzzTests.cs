namespace FizzBuzz
{
    using Xunit;

    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void RegularNumber(int regularNumber)
        {
            Assert.Equal(regularNumber.ToString(), FizzBuzz(regularNumber));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void FizzNumber(int fizzNumber)
        {
            Assert.Equal("Fizz", FizzBuzz(fizzNumber));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void BuzzNumber(int buzzNumber)
        {
            Assert.Equal("Buzz", FizzBuzz(buzzNumber));
        }

        [Fact]
        public void FizzBuzzNumber()
        {
            Assert.Equal("FizzBuzz", FizzBuzz(15));
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
