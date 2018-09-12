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

        [Fact]
        public void FizzNumber()
        {
            Assert.Equal("Fizz", FizzBuzz(3));
        }

        private string FizzBuzz(int value)
        {
            if (value == 3)
            {
                return "Fizz";
            }

            return value.ToString();
        }
    }
}
