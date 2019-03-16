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
        [MemberData(nameof(CanMoveForwardData))]
        public void MarsRoverCanMoveForward(RoverState initial, List<string> commands, RoverState expected)
        {
            var rover = new Rover(initial);

            rover.Execute(commands);

            rover.RoverState.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(CanTurnRightData))]
        public void MarsRoverCanTurnRight(RoverState initial, List<string> commands, RoverState expected)
        {
            var rover = new Rover(initial);

            rover.Execute(commands);

            rover.RoverState.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(CanTurnLeftData))]
        public void MarsRoverCanTurnLeft(RoverState initial, List<string> commands, RoverState expected)
        {
            var rover = new Rover(initial);

            rover.Execute(commands);

            rover.RoverState.ShouldBe(expected);
        }

        public static IEnumerable<object[]> CanTurnRightData =>
            new List<object[]>
            {
                // Facing north turn right 1 step
                new object[] {RoverInMiddleFacing("N"), new List<string> {"r"}, RoverInMiddleFacing("E")},
                // Facing north turn right 2 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"r", "r"}, RoverInMiddleFacing("S")},
                // Facing north turn right 3 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"r", "r", "r"}, RoverInMiddleFacing("W")},
                // Facing north turn right 4 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"r", "r", "r", "r" }, RoverInMiddleFacing("N")},
                // Facing north turn right 5 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"r", "r", "r", "r", "r" }, RoverInMiddleFacing("E")},
            };

        public static IEnumerable<object[]> CanTurnLeftData =>
            new List<object[]>
            {
                // Facing north turn right 1 step
                new object[] {RoverInMiddleFacing("N"), new List<string> {"l"}, RoverInMiddleFacing("W")},
                // Facing north turn right 2 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"l", "l"}, RoverInMiddleFacing("S")},
                // Facing north turn right 3 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"l", "l", "l"}, RoverInMiddleFacing("E")},
                new object[] {RoverInMiddleFacing("N"), new List<string> {"l", "l", "l", "l" }, RoverInMiddleFacing("N")},
                // Facing north turn right 5 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"l", "l", "l", "l", "l" }, RoverInMiddleFacing("W")},
            };

        public static IEnumerable<object[]> CanMoveForwardData =>
            new List<object[]>
            {
                // Move forward north 1 step
                new object[] {RoverInMiddleFacing("N"), new List<string> {"f"}, new RoverState(0, 1, "N")},
                // Move forward north 2 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"f", "f"}, new RoverState(0, 2, "N")},
                // Move forward north 3 steps
                new object[] {RoverInMiddleFacing("N"), new List<string> {"f", "f", "f"}, new RoverState(0, 3, "N")},
                // Move forward east 1 step
                new object[] {RoverInMiddleFacing("E"), new List<string> {"f"}, new RoverState(1, 0, "E")},
                // Move forward east 2 steps
                new object[] {RoverInMiddleFacing("E"), new List<string> {"f", "f"}, new RoverState(2, 0, "E")},
                // Move forward east 3 steps
                new object[] {RoverInMiddleFacing("E"), new List<string> {"f", "f", "f"}, new RoverState(3, 0, "E")},
                // Move forward south 1 step
                new object[] {RoverInMiddleFacing("S"), new List<string> {"f"}, new RoverState(0, -1, "S")},
                // Move forward south 2 steps
                new object[] {RoverInMiddleFacing("S"), new List<string> {"f", "f"}, new RoverState(0, -2, "S")},
                // Move forward south 3 steps
                new object[] {RoverInMiddleFacing("S"), new List<string> {"f", "f", "f"}, new RoverState(0, -3, "S")},
                // Move forward west 1 step
                new object[] {RoverInMiddleFacing("W"), new List<string> {"f"}, new RoverState(-1, 0, "W")},
                // Move forward west 2 steps
                new object[] {RoverInMiddleFacing("W"), new List<string> {"f", "f"}, new RoverState(-2, 0, "W")},
                // Move forward west 3 steps
                new object[] {RoverInMiddleFacing("W"), new List<string> {"f", "f", "f"}, new RoverState(-3, 0, "W")},
            };

        private static RoverState RoverInMiddleFacing(string direction)
        {
            return new RoverState(0, 0, direction);
        }
    }
}
