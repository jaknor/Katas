namespace MarsRover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Planet
    {
        private readonly int _limit;
        private readonly List<Position> _blockedPositions;

        public Planet(int limit, List<Position> blockedPositions)
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
            if (AtTheLimit())
            {
                var coordinateAdjustedForLimit = _limit + 1;
                return TopLimit() >= 0 ? -coordinateAdjustedForLimit : coordinateAdjustedForLimit;
            }

            return coordinate;

            bool AtTheLimit()
            {
                return Math.Abs(coordinate) == _limit;
            }

            int TopLimit()
            {
                return Math.Sign(coordinate);
            }
        }
    }
}