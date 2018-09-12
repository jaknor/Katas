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

        [Fact]
        public void BuzzNumber()
        {
            Assert.Equal("Buzz", FizzBuzz(5));
        }

        private string FizzBuzz(int value)
        {
            if (value % 3 == 0)
            {
                return "Fizz";
            }

            if (value == 5)
            {
                return "Buzz";
            }

            return value.ToString();
        }
    }
}
