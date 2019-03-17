namespace MarsRover
{
    using System.Collections.Generic;
    using System.Linq;

    public class Planet
    {
        private readonly List<Position> _blockedPositions;

        public Planet(List<Position> blockedPositions)
        {
            _blockedPositions = blockedPositions;
        }

        public TileStatus GetStatus(Position position)
        {
            return _blockedPositions.Any(bp => Equals(bp, position)) ? TileStatus.Blocked : TileStatus.Free;
        }
    }
}