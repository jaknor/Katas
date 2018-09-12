using System;
using System.Collections.Generic;
using Xunit;

namespace Fibonacci
{
    public class FibonacciTests
    {
        [Fact]
        public void PositionZero()
        {
            Assert.Equal(0, Fibonacci(0));
        }

        [Fact]
        public void PositionOne()
        {
            Assert.Equal(1, Fibonacci(1));
        }

        private int Fibonacci(int position)
        {
            return position;
        }
    }
}
