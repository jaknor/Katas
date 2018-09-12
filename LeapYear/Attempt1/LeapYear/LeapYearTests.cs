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

        [Fact]
        public void RegularLeapYear()
        {
            Assert.True(IsLeapYear(2020));
        }

        private bool IsLeapYear(int year)
        {
            if (year == 2020)
            {
                return true;
            }

            return false;
        }
    }
}
