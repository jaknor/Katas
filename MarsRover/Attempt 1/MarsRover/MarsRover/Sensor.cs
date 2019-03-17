namespace MarsRover
{
    public class Sensor
    {
        private bool _isStuck;

        public Sensor()
        {
            _isStuck = false;
        }

        public bool CanMoveToTile(Planet planet, Position plannedPosition)
        {
            var tileStatus = planet.GetStatus(plannedPosition);

            _isStuck = Equals(tileStatus, TileStatus.Blocked);

            return Equals(tileStatus, TileStatus.Free);
        }

        public bool IsStuck()
        {
            return _isStuck;
        }
    }
}