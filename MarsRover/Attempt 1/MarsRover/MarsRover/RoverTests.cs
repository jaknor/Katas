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
            var rover = new Rover(new RoverState(5, 3, "S"));

            rover.RoverState.ShouldBe(new RoverState(5, 3, "S"));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void MarsRoverCanExecuteCommands(RoverState initial, List<string> commands, RoverState expected)
        {
            var rover = new Rover(initial);

            rover.Execute(commands);

            rover.RoverState.ShouldBe(expected);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                // Move forward north 1 step
                new object[] { new RoverState(0, 0, "N"),  new List<string> { "f" }, new RoverState(0, 1, "N")   },
                // Move forward north 2 steps
                new object[] { new RoverState(0, 0, "N"),  new List<string> { "f", "f" }, new RoverState(0, 2, "N")   },
                // Move forward north 3 steps
                new object[] { new RoverState(0, 0, "N"),  new List<string> { "f", "f", "f" }, new RoverState(0, 3, "N")   },
                // Move forward east 1 step
                new object[] { new RoverState(0, 0, "E"),  new List<string> { "f" }, new RoverState(1, 0, "E")   },
                // Move forward east 2 steps
                new object[] { new RoverState(0, 0, "E"),  new List<string> { "f", "f" }, new RoverState(2, 0, "E")   },
                // Move forward east 3 steps
                new object[] { new RoverState(0, 0, "E"),  new List<string> { "f", "f", "f" }, new RoverState(3, 0, "E")   },
            };
    }
}
