namespace BowlingKata
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Game
    {
        private const int MaxNrOfFrames = 10;
        private readonly List<Frame> _frames;
        
        public Game()
        {
            _frames = new List<Frame> {new Frame()};
        }

        public int Score()
        {
            var score = 0;

            var nrOfFrames = _frames.Count > MaxNrOfFrames ? MaxNrOfFrames : _frames.Count;

            for (int i = 0; i < nrOfFrames; i++)
            {
                score += _frames[i].Score();

                score += ScoreForSpare(i);

                score += ScoreForStrike(i);
            }

            return score;
        }

        private int ScoreForStrike(int i)
        {
            var score = 0;

            if (_frames[i].WasStrike() && ThereAreEnoughFramesLeft(i, _frames.Count, 1))
            {
                score += _frames[i + 1].Score();
                if (_frames[i + 1].WasStrike() && ThereAreEnoughFramesLeft(i, _frames.Count, 2))
                {
                    score += _frames[i + 2].Score();
                }
            }

            return score;
        }

        private int ScoreForSpare(int i)
        {
            if (_frames[i].WasSpare() && ThereAreEnoughFramesLeft(i, _frames.Count, 1))
            {
                return _frames[i + 1].ScoreOfFirstThrow();
            }

            return 0;
        }

        private bool ThereAreEnoughFramesLeft(int currentFrameIndex, int nrOfFrames, int nrOfRequiredFrames)
        {
            return currentFrameIndex < nrOfFrames - nrOfRequiredFrames;
        }


        public void Roll(int numberOfPinsKnockedDown)
        {
            if (numberOfPinsKnockedDown >= 0 && numberOfPinsKnockedDown <= 10)
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