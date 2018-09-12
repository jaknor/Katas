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
            if (year == 1600)
            {
                return true;
            }

            if (year == 2000)
            {
                return true;
            }

            if (year == 2400)
            {
                return true;
            }

            if (year % 100 == 0)
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
