namespace TicTacToe
{
    using Microsoft.VisualBasic.CompilerServices;

    public class Piece
    {
        private readonly char _type;

        public Piece(char type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return _type.ToString();
        }

        public bool IsEmpty()
        {
            return _type == 'E';
        }

        public bool CannotBeFirstMove()
        {
            return _type != 'X';
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return _type;
        }
    }
}