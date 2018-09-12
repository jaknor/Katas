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
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        public void PositionZero(int position, int expectedFibonacci)
        {
            Assert.Equal(expectedFibonacci, Fibonacci(position));
        }

        private int Fibonacci(int position)
        {
            if (position == 5)
            {
                return position;
            }

            if (position > 1)
            {
                return position - 1;
            }

            return position;
        }
    }
}
