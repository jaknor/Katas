namespace BowlingKata
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly List<Frame> _frames;
        
        public Game()
        {
            _frames = new List<Frame> {new Frame()};
        }

        public int Score()
        {
            var score = 0;

            for (int i = 0; i < _frames.Count; i++)
            {
                score += _frames[i].Score();
                if (_frames[i].WasStrike() || _frames[i].WasSpare())
                {
                    if (i < _frames.Count - 1)
                    {
                        score += _frames[i + 1].Score();
                    }

                    if (_frames[i].WasStrike())
                    {
                        if (i < _frames.Count - 2)
                        {
                            score += _frames[i + 2].Score();
                        }
                    }
                }
            }

            return score;
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            if (numberOfPinsKnockedDown > 0 && numberOfPinsKnockedDown <= 10)
            {
                _frames.Last().Score(numberOfPinsKnockedDown);

                if (_frames.Last().Complete())
                {
                    _frames.Add(new Frame());
                }
            }
        }
    }
}