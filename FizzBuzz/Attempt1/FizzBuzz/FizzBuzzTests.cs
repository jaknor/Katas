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

        private string FizzBuzz(int value)
        {
            if (value % 3 == 0)
            {
                return "Fizz";
            }

            if (value % 5 == 0)
            {
                return "Buzz";
            }

            return value.ToString();
        }
    }
}
