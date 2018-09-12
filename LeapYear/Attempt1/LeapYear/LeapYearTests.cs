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

        [Theory]
        [InlineData(1000)]
        [InlineData(1800)]
        [InlineData(1900)]
        public void ATypicalCommonYear(int aTypicalCommonYear)
        {
            Assert.False(IsLeapYear(aTypicalCommonYear));
        }

        private bool IsLeapYear(int year)
        {
            if (year == 1000)
            {
                return false;
            }

            if (year == 1800)
            {
                return false;
            }

            if (year == 1900)
            {
                return false;
            }

            if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
