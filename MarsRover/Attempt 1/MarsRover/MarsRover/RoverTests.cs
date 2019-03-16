namespace MarsRover
{
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

        [Fact]
        public void MarsRoverCanMoveForward()
        {
            var rover = new Rover(0, 0, "N");

            rover.Execute("f");

            rover.X.ShouldBe(0);
            rover.Y.ShouldBe(1);
            rover.Direction.ShouldBe("N");
        }
    }
}
