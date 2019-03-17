namespace MarsRover
{
    using System.Collections.Generic;
    using System.Linq;

    public class Planet
    {
        private readonly Limit _limit;
        private readonly List<Position> _blockedPositions;

        public Planet(Limit limit, List<Position> blockedPositions)
        {
            _limit = limit;
            _blockedPositions = blockedPositions;
        }

        public TileStatus GetStatus(Position position)
        {
            return _blockedPositions.Any(bp => Equals(bp, position)) ? TileStatus.Blocked : TileStatus.Free;
        }

        public int AdjustForLimitReached(int coordinate)
        {
            return _limit.AdjustForLimitReached(coordinate);
        }
    }
}