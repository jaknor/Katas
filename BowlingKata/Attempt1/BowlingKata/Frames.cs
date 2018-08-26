namespace BowlingKata
{
    using System.Collections.Generic;

    public class Frames
    {
        private const int MaxNrOfFrames = 10;

        private readonly List<Frame> _frames;

        public Frames()
        {
            _frames = new List<Frame>();
        }

        public void Add(Frame frame)
        {
            _frames.Add(frame);
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
                score += ScoreOfNextFrame(indexOfFrame);
                if (NextFrameIsStrike(indexOfFrame))
                {
                    score += ScoreOfNextNextFrame(indexOfFrame);
                }
            }

            return score;
        }

        private int ScoreOfNextNextFrame(int indexOfFrame)
        {
            return _frames[indexOfFrame + 2].ScoreOfFirstThrow();
        }

        private int ScoreOfNextFrame(int indexOfFrame)
        {
            return _frames[indexOfFrame + 1].Score();
        }

        private int AdditionalScoreIfSpare(int i)
        {
            if (_frames[i].WasSpare() && ThereAreEnoughFramesLeft(i, _frames.Count, 1))
            {
                return _frames[i + 1].ScoreOfFirstThrow();
            }

            return 0;
        }

        private bool NextFrameIsStrike(int i)
        {
            return FrameIsStrike(i + 1);
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