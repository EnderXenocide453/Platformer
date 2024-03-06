using UnityEngine;

namespace ScoreManagement
{
    public static class LevelScore
    {
        private static int _scorePoints;
        public static int CurrentScorePoints
        {
            get => _scorePoints;
            set
            {
                _scorePoints = value;
                onScoreChanges?.Invoke();
            }
        }

        public delegate void ScoreEventHandler();
        public static event ScoreEventHandler onScoreChanges;

        public static void Reset()
        {
            CurrentScorePoints = 0;
        }

        public static void AddScorePoints(int points)
        {
            CurrentScorePoints += points;
        }
    }
}
