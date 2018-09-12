namespace LeapYear
{
    using Xunit;

    public class LeapYearTests
    {
        [Fact]
        public void NotALeapYear()
        {
            Assert.False(IsLeapYear(2017));
        }

        [Theory]
        [InlineData(2016)]
        [InlineData(2020)]
        [InlineData(2024)]
        public void RegularLeapYear(int regularLeapYear)
        {
            Assert.True(IsLeapYear(regularLeapYear));
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(1800)]
        [InlineData(1900)]
        public void ATypicalCommonYear(int aTypicalCommonYear)
        {
            Assert.False(IsLeapYear(aTypicalCommonYear));
        }

        [Theory]
        [InlineData(1600)]
        [InlineData(2000)]
        [InlineData(2400)]
        public void ATypicalLeapYear(int aTypicalLeapYear)
        {
            Assert.True(IsLeapYear(aTypicalLeapYear));
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
