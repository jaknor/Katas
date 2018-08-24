namespace BowlingKata
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private const int MaxNrOfFrames = 10;
        private readonly List<Frame> _frames;
        
        public Game()
        {
            _frames = new List<Frame> {new Frame()};
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

        public int Score()
        {
            var score = 0;

            var nrOfFrames = _frames.Count > MaxNrOfFrames ? MaxNrOfFrames : _frames.Count;

            for (int indexOfFrame = 0; indexOfFrame < nrOfFrames; indexOfFrame++)
            {
                score += _frames[indexOfFrame].Score();

                score += AdditionalScoreIfStrike(indexOfFrame);

                score += AdditionalScoreIfSpare(indexOfFrame);
            }

            return score;
        }

        private int AdditionalScoreIfStrike(int indexOfFrame)
        {
            var score = 0;

            if (FrameIsStrike(indexOfFrame))
            {
                score += _frames[indexOfFrame + 1].Score();
                if (FrameIsStrike(indexOfFrame + 1))
                {
                    score += _frames[indexOfFrame + 2].Score();
                }
            }

            return score;
        }

        private int AdditionalScoreIfSpare(int i)
        {
            if (_frames[i].WasSpare() && ThereAreEnoughFramesLeft(i, _frames.Count, 1))
            {
                return _frames[i + 1].ScoreOfFirstThrow();
            }

            return 0;
        }

        private bool FrameIsStrike(int i)
        {
            return _frames[i].WasStrike() && ThereAreEnoughFramesLeft(i, _frames.Count, 1);
        }

        private bool ThereAreEnoughFramesLeft(int currentFrameIndex, int nrOfFrames, int nrOfRequiredFrames)
        {
            return currentFrameIndex < nrOfFrames - nrOfRequiredFrames;
        }
    }
}