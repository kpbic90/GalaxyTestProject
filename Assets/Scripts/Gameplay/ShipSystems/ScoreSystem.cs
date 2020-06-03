using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private int score;

        public void AddScore()
        {
            GameScoreKeeper.Score += score;
        }
    }
}