namespace MarsRover
{
    public class TileStatus
    {
        private readonly string _status;

        public static TileStatus Free = new TileStatus("Free");

        public static TileStatus Blocked = new TileStatus("Blocked");

        public TileStatus(string status)
        {
            _status = status;
        }

        protected bool Equals(TileStatus other)
        {
            return string.Equals(_status, other._status);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TileStatus) obj);
        }

        public override int GetHashCode()
        {
            return (_status != null ? _status.GetHashCode() : 0);
        }
    }
}