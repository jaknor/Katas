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

        private int Fibonacci(int position)
        {
            return 0;
        }
    }
}
