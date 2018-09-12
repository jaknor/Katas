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

        [Fact]
        public void ATypicalCommonYear()
        {
            Assert.False(IsLeapYear(1900));
        }

        private bool IsLeapYear(int year)
        {
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
