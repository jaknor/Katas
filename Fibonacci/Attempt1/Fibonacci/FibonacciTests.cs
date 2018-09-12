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
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        public void PositionZero(int position, int expectedFibonacci)
        {
            Assert.Equal(expectedFibonacci, Fibonacci(position));
        }

        private int Fibonacci(int position)
        {
            if (position > 1)
            {
                return Fibonacci(position - 1) + Fibonacci(position - 2);
            }

            return position;
        }
    }
}
