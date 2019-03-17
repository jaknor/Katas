namespace MarsRover
{
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

        public int AdjustForLimit(int coordinate)
        {
            if (AboveTopLimit())
            {
                return CoordinateOfBottomLimit();
            }

            if (BelowBottomLimit())
            {
                return CoordinateOfTopLimit();
            }

            return coordinate;

            bool AboveTopLimit()
            {
                return coordinate > CoordinateOfTopLimit();
            }

            bool BelowBottomLimit()
            {
                return coordinate < CoordinateOfBottomLimit();
            }

            int CoordinateOfTopLimit()
            {
                return _limit;
            }

            int CoordinateOfBottomLimit()
            {
                return -_limit;
            }
        }
    }
}