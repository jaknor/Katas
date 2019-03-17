namespace MarsRover
{
    using System;

    public class Limit
    {
        private readonly int _limit;

        public Limit(int limit)
        {
            _limit = limit;
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