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

        private string FizzBuzz(int value)
        {
            return value.ToString();
        }
    }
}
