namespace TicTacToe
{
    public class Piece
    {
        private readonly string _type;

        public Piece(string type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return _type;
        }

        public bool IsEmpty()
        {
            return _type == "E";
        }

        public bool CannotBeFirstMove()
        {
            return _type != "X";
        }
    }
}