using UnityEngine;

namespace ScoreManagement
{
    public class ScoreObject : MonoBehaviour
    {
        [SerializeField] int score;

        public void PickUp()
        {
            LevelScore.AddScorePoints(score);
            Destroy(this);
        }
    }
}