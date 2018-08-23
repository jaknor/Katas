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

                score += ScoreFromNextFrame(i);

                score += ScoreFromNextNextFrame(i);
            }

            return score;
        }

        private int ScoreFromNextNextFrame(int i)
        {
            if (AddScoreFromNextNextFrame(i))
            {
                return _frames[i + 2].Score();
            }

            return 0;
        }

        private int ScoreFromNextFrame(int i)
        {
            if (AddScoreFromNextFrame(i))
            {
                return _frames[i + 1].Score();
            }

            return 0;
        }

        private bool AddScoreFromNextNextFrame(int i)
        {
            return _frames[i].WasStrike() && ThereAreEnoughFramesLeft(i, _frames.Count, 2);
        }

        private bool AddScoreFromNextFrame(int i)
        {
            return (_frames[i].WasStrike() || _frames[i].WasSpare()) && ThereAreEnoughFramesLeft(i, _frames.Count, 1);
        }

        private bool ThereAreEnoughFramesLeft(int currentFrameIndex, int nrOfFrames, int nrOfRequiredFrames)
        {
            return currentFrameIndex < nrOfFrames - nrOfRequiredFrames;
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