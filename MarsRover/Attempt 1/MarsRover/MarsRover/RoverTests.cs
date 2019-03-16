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
    }
}
