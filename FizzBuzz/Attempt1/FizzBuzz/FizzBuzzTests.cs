namespace FizzBuzz
{
    using Xunit;

    public class FizzBuzzTests
    {
        [Fact]
        public void RegularNumber()
        {
            Assert.Equal("1", FizzBuzz(1));
        }

        private string FizzBuzz(int value)
        {
            return "1";
        }
    }
}
