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
            var commandCenter = new RoverCommandCenter(new Rover(new Position( 5, 3), Direction.South));

            commandCenter.Rover.ShouldBe(new Rover(new Position(5, 3), Direction.South));
        }

        [Theory]
        [MemberData(nameof(CanMoveForwardData))]
        public void MarsRoverCanMoveForward(Rover initial, List<string> commands, Rover expected)
        {
            var commandCenter = new RoverCommandCenter(initial);

            commandCenter.Execute(commands);

            commandCenter.Rover.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(CanMoveBackwardsData))]
        public void MarsRoverCanMoveBackwards(Rover initial, List<string> commands, Rover expected)
        {
            var commandCenter = new RoverCommandCenter(initial);

            commandCenter.Execute(commands);

            commandCenter.Rover.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(CanTurnRightData))]
        public void MarsRoverCanTurnRight(Rover initial, List<string> commands, Rover expected)
        {
            var commandCenter = new RoverCommandCenter(initial);

            commandCenter.Execute(commands);

            commandCenter.Rover.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(CanTurnLeftData))]
        public void MarsRoverCanTurnLeft(Rover initial, List<string> commands, Rover expected)
        {
            var commandCenter = new RoverCommandCenter(initial);

            commandCenter.Execute(commands);

            commandCenter.Rover.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(WrapData), parameters: 10)]
        public void MovingWhenAtTheEdgeShouldWrap(Rover initial, List<string> commands, Rover expected)
        {
            var commandCenter = new RoverCommandCenter(initial, 10);

            commandCenter.Execute(commands);

            commandCenter.Rover.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(ObstacleData), parameters: 10)]
        public void StopsAtObstacle(Rover initial, List<string> commands, Rover expected, Planet planet)
        {
            var commandCenter = new RoverCommandCenter(initial, planet);

            commandCenter.Execute(commands);

            commandCenter.Rover.ShouldBe(expected);
        }

        [Fact]
        public void CanContinueAfterStoppingAtObstacle()
        {
            var commandCenter = new RoverCommandCenter(new Rover(new Position(0, 0), Direction.North), new Planet(10, new List<Position> { new Position(0, 1) }));

            commandCenter.Execute(new List<string> { "f", "l", "f", "f" });

            commandCenter.Execute(new List<string> { "l", "f", "f", "r", "f" });

            commandCenter.Rover.ShouldBe(new Rover(new Position(-2, 1), Direction.North));
        }

        public static IEnumerable<object[]> ObstacleData(int limit) =>
            new List<object[]>
            {
                // Move forward 1 step when facing north and there is an obstacle in front of you
                new object[] { new Rover(new Position(0, 0), Direction.North), new List<string> {"f"}, new Rover(new Position(0, 0), Direction.North), new Planet(limit, new List<Position> { new Position(0, 1) })},
                // Move backward 1 step when facing north and there is an obstacle behind you
                new object[] { new Rover(new Position(0, 0), Direction.North), new List<string> {"b"}, new Rover(new Position(0, 0), Direction.North), new Planet(limit, new List<Position> { new Position(0, -1) })},
                // Move forward 1 step when facing west and there is an obstacle in front of you
                new object[] { new Rover(new Position(0, 0), Direction.West), new List<string> {"f"}, new Rover(new Position(0, 0), Direction.West), new Planet(limit, new List<Position> { new Position(-1, 0) })},
                // Move backward 1 step when facing south and there is an obstacle behind you
                new object[] { new Rover(new Position(0, 0), Direction.South), new List<string> {"b"}, new Rover(new Position(0, 0), Direction.South), new Planet(limit, new List<Position> { new Position(0, 1) })},
                
                // Does not keep moving after encountering obstacle
                new object[] { new Rover(new Position(0, 0), Direction.North), new List<string> {"f", "l", "f", "f"}, new Rover(new Position(0, 0), Direction.North), new Planet(limit, new List<Position> { new Position(0, 1) })},

            };

        public static IEnumerable<object[]> WrapData(int limit) =>
            new List<object[]>
            {
                // Move forward 1 step when facing north and at the top edge
                new object[] { new Rover(new Position(0, limit), Direction.North), new List<string> {"f"}, new Rover(new Position(0, -limit), Direction.North)},
                // Move forward 1 step when facing south and at the bottom edge
                new object[] { new Rover(new Position(0, -limit), Direction.South), new List<string> {"f"}, new Rover(new Position(0, limit), Direction.South)},
                // Move backwards 1 step when facing north and at the bottom edge
                new object[] { new Rover(new Position(0, -limit), Direction.North), new List<string> {"b"}, new Rover(new Position(0, limit), Direction.North)},
                // Move backwards 1 step when facing south and at the top edge
                new object[] { new Rover(new Position(0, limit), Direction.South), new List<string> {"b"}, new Rover(new Position(0, -limit), Direction.South)},

                // Move forward 1 step when facing east and at the right edge
                new object[] { new Rover(new Position(limit, 0), Direction.East), new List<string> {"f"}, new Rover(new Position(-limit, 0), Direction.East)},
                // Move forward 1 step when facing west and at the left edge
                new object[] { new Rover(new Position(-limit, 0), Direction.West), new List<string> {"f"}, new Rover(new Position(limit, 0), Direction.West)},
                // Move backwards 1 step when facing east and at the left edge
                new object[] { new Rover(new Position(-limit, 0), Direction.East), new List<string> {"b"}, new Rover(new Position(limit, 0), Direction.East)},
                // Move backwards 1 step when facing west and at the right edge
                new object[] { new Rover(new Position(limit, 0), Direction.West), new List<string> {"b"}, new Rover(new Position(-limit, 0), Direction.West)},
            };

        public static IEnumerable<object[]> CanTurnRightData =>
            new List<object[]>
            {
                // Facing north turn right 1 step
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"r"}, RoverInMiddleFacing(Direction.East)},
                // Facing north turn right 2 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"r", "r"}, RoverInMiddleFacing(Direction.South)},
                // Facing north turn right 3 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"r", "r", "r"}, RoverInMiddleFacing(Direction.West)},
                // Facing north turn right 4 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"r", "r", "r", "r" }, RoverInMiddleFacing(Direction.North)},
                // Facing north turn right 5 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"r", "r", "r", "r", "r" }, RoverInMiddleFacing(Direction.East)},
            };

        public static IEnumerable<object[]> CanTurnLeftData =>
            new List<object[]>
            {
                // Facing north turn right 1 step
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"l"}, RoverInMiddleFacing(Direction.West)},
                // Facing north turn right 2 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"l", "l"}, RoverInMiddleFacing(Direction.South)},
                // Facing north turn right 3 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"l", "l", "l"}, RoverInMiddleFacing(Direction.East)},
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"l", "l", "l", "l" }, RoverInMiddleFacing(Direction.North)},
                // Facing north turn right 5 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"l", "l", "l", "l", "l" }, RoverInMiddleFacing(Direction.West)},
            };

        public static IEnumerable<object[]> CanMoveForwardData =>
            new List<object[]>
            {
                // Move forward north 1 step
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"f"}, new Rover(new Position(0, 1), Direction.North)},
                // Move forward north 2 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"f", "f"}, new Rover(new Position(0, 2), Direction.North)},
                // Move forward north 3 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"f", "f", "f"}, new Rover(new Position(0, 3), Direction.North)},
                // Move forward east 1 step
                new object[] {RoverInMiddleFacing(Direction.East), new List<string> {"f"}, new Rover(new Position(1, 0), Direction.East)},
                // Move forward east 2 steps
                new object[] {RoverInMiddleFacing(Direction.East), new List<string> {"f", "f"}, new Rover(new Position(2, 0), Direction.East)},
                // Move forward east 3 steps
                new object[] {RoverInMiddleFacing(Direction.East), new List<string> {"f", "f", "f"}, new Rover(new Position(3, 0), Direction.East)},
                // Move forward south 1 step
                new object[] {RoverInMiddleFacing(Direction.South), new List<string> {"f"}, new Rover(new Position(0, -1), Direction.South)},
                // Move forward south 2 steps
                new object[] {RoverInMiddleFacing(Direction.South), new List<string> {"f", "f"}, new Rover(new Position(0, -2), Direction.South)},
                // Move forward south 3 steps
                new object[] {RoverInMiddleFacing(Direction.South), new List<string> {"f", "f", "f"}, new Rover(new Position(0, -3), Direction.South)},
                // Move forward west 1 step
                new object[] {RoverInMiddleFacing(Direction.West), new List<string> {"f"}, new Rover(new Position(-1, 0), Direction.West)},
                // Move forward west 2 steps
                new object[] {RoverInMiddleFacing(Direction.West), new List<string> {"f", "f"}, new Rover(new Position(-2, 0), Direction.West)},
                // Move forward west 3 steps
                new object[] {RoverInMiddleFacing(Direction.West), new List<string> {"f", "f", "f"}, new Rover(new Position(-3, 0), Direction.West)},
            };

        public static IEnumerable<object[]> CanMoveBackwardsData =>
            new List<object[]>
            {
                // Move forward north 1 step
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"b"}, new Rover(new Position(0, -1), Direction.North)},
                // Move forward north 2 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"b", "b"}, new Rover(new Position(0, -2), Direction.North)},
                // Move forward north 3 steps
                new object[] {RoverInMiddleFacing(Direction.North), new List<string> {"b", "b", "b"}, new Rover(new Position(0, -3), Direction.North)},
                // Move forward east 1 step
                new object[] {RoverInMiddleFacing(Direction.East), new List<string> {"b"}, new Rover(new Position(-1, 0), Direction.East)},
                // Move forward east 2 steps
                new object[] {RoverInMiddleFacing(Direction.East), new List<string> {"b", "b"}, new Rover(new Position(-2, 0), Direction.East)},
                // Move forward east 3 steps
                new object[] {RoverInMiddleFacing(Direction.East), new List<string> {"b", "b", "b"}, new Rover(new Position(-3, 0), Direction.East)},
                // Move forward south 1 step
                new object[] {RoverInMiddleFacing(Direction.South), new List<string> {"b"}, new Rover(new Position(0, 1), Direction.South)},
                // Move forward south 2 steps
                new object[] {RoverInMiddleFacing(Direction.South), new List<string> {"b", "b"}, new Rover(new Position(0, 2), Direction.South)},
                // Move forward south 3 steps
                new object[] {RoverInMiddleFacing(Direction.South), new List<string> {"b", "b", "b"}, new Rover(new Position(0, 3), Direction.South)},
                // Move forward west 1 step
                new object[] {RoverInMiddleFacing(Direction.West), new List<string> {"b"}, new Rover(new Position(1, 0), Direction.West)},
                // Move forward west 2 steps
                new object[] {RoverInMiddleFacing(Direction.West), new List<string> {"b", "b"}, new Rover(new Position(2, 0), Direction.West)},
                // Move forward west 3 steps
                new object[] {RoverInMiddleFacing(Direction.West), new List<string> {"b", "b", "b"}, new Rover(new Position(3, 0), Direction.West)},
            };

        private static Rover RoverInMiddleFacing(Direction direction)
        {
            return new Rover(new Position(0, 0), direction);
        }
    }
}
