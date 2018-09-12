namespace LeapYear
{
    using Xunit;

    public class LeapYearTests
    {
        [Theory]
        [InlineData(2017, false)]
        [InlineData(1000, false)]
        [InlineData(1600, true)]
        [InlineData(1800, false)]
        [InlineData(1900, false)]
        [InlineData(2000, true)]
        [InlineData(2016, true)]
        [InlineData(2020, true)]
        [InlineData(2024, true)]
        [InlineData(2400, true)]
        public void CheckLeapYear(int year, bool expectedValue)
        {
            Assert.Equal(expectedValue, IsLeapYear(year));
        }

        private bool IsLeapYear(int year)
        {
            if (year.IsDividableBy(400))
            {
                return true;
            }

            if (year.IsDividableBy(100))
            {
                return false;
            }

            if (year.IsDividableBy(4))
            {
                return true;
            }

            return false;
        }


    }
}
