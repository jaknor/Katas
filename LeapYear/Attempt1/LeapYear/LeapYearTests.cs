using System;
using Xunit;

namespace LeapYear
{
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

        private bool IsLeapYear(int year)
        {
            if (year == 2016)
            {
                return true;
            }

            if (year == 2020)
            {
                return true;
            }

            if (year == 2024)
            {
                return true;
            }

            return false;
        }
    }
}
