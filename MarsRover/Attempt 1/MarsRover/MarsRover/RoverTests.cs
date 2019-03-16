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
                new object[] { new RoverState(0, 0, "N"),  new List<string> { "f "}, new RoverState(0, 1, "N")   },
                new object[] { new RoverState(0, 0, "N"),  new List<string> { "f ", "f"}, new RoverState(0, 2, "N")   },
                new object[] { new RoverState(0, 0, "N"),  new List<string> { "f ", "f", "f"}, new RoverState(0, 3, "N")   },
            };
    }
}
