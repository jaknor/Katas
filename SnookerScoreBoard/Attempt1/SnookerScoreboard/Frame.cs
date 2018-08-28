namespace SnookerScoreboard
{
    public class Frame
    {
        private Player _currentPlayer;
        private readonly Player _player1;
        private readonly Player _player2;
        private AvailableBalls _availableBalls;

        public Frame()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            _currentPlayer = _player1;
            _availableBalls = new AvailableBalls();
        }

        public void AddShot(Shot shot)
        {
            _availableBalls.AddShot(shot);

            if (shot.Foul())
            {
                Opponent().IncreaseScore(shot.Penalty());
            }

            if (shot.OtherPlayersTurn())
            {
                _currentPlayer = Opponent();
                _currentPlayer.ResetBreak();
                return;
            }

            _currentPlayer.IncreaseScore(shot.Score());
        }

        public override string ToString()
        {
            return $"Current Player: {_currentPlayer.Name}. Score: {_player1.Score} - {_player2.Score}. Break: {_currentPlayer.Break()}. Remaining Points: {_availableBalls.RemainingPoints()}";
        }

        private Player Opponent()
        {
            return _currentPlayer == _player1 ? _player2 : _player1;
        }
    }
}