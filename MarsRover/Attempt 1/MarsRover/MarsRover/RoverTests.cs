namespace MarsRover
{
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class RoverTests
    {
        [Fact]
        public void MarsRoverPosition()
        {
            var rover = new Rover(5,3, "S");

            rover.X.ShouldBe(5);
            rover.Y.ShouldBe(3);
            rover.Direction.ShouldBe("S");
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void MarsRoverCanExecuteCommands(List<string> commands, int expectedY)
        {
            var rover = new Rover(0, 0, "N");

            rover.Execute(commands);

            rover.X.ShouldBe(0);
            rover.Y.ShouldBe(expectedY);
            rover.Direction.ShouldBe("N");
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { new List<string> { "f "}, 1  },
                new object[] { new List<string> { "f ", "f"}, 2  },
                new object[] { new List<string> { "f ", "f", "f"}, 3  }
            };
    }
}
