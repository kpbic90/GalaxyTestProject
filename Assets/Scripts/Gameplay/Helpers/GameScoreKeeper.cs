using System;

namespace Gameplay.Helpers
{
    public static class GameScoreKeeper
    {
        public static EventHandler<int> OnScoreChange;

        private static int score;

        public static int Score
        {
            get => score;
            set
            {
                score = value;
                OnScoreChange(null, score);
            }
        }
    }
}