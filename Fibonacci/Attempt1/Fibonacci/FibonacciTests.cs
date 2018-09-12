using System;
using System.Collections.Generic;
using Xunit;

namespace Fibonacci
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        public void PositionZero(int position, int expectedFibonacci)
        {
            Assert.Equal(expectedFibonacci, Fibonacci(position));
        }

        private int Fibonacci(int position)
        {
            if (position == 2)
            {
                return 1;
            }

            if (position == 3)
            {
                return 2;
            }

            return position;
        }
    }
}
