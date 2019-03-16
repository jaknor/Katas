namespace MarsRover
{
    public class MoveCommand
    {
        protected int MoveNorth(Rover rover, int limit)
        {
            var currentY = rover.Y;
            if (currentY == limit)
            {
                currentY = -(limit + 1);
            }

            return currentY + 1;
        }

        protected int MoveEast(Rover rover, int limit)
        {
            var currentX = rover.X;
            if (currentX == limit)
            {
                currentX = -(limit + 1);
            }

            return currentX + 1;
        }

        protected int MoveSouth(Rover rover, int limit)
        {
            var currentY = rover.Y;
            if (currentY == -limit)
            {
                currentY = limit + 1;
            }

            return currentY - 1;
        }

        protected int MoveWest(Rover rover, int limit)
        {
            var currentX = rover.X;
            if (currentX == -limit)
            {
                currentX = (limit + 1);
            }

            return currentX - 1;
        }
    }
}