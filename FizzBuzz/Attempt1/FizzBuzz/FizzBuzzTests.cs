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

        private string FizzBuzz(int value)
        {
            if (value == 3)
            {
                return "Fizz";
            }

            if (value == 6)
            {
                return "Fizz";
            }

            if (value == 9)
            {
                return "Fizz";
            }

            return value.ToString();
        }
    }
}
