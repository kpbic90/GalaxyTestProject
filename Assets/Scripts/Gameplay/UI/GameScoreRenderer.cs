using Gameplay.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class GameScoreRenderer : MonoBehaviour
    {
        [SerializeField] private Text textScore;

        public void Start()
        {
            GameScoreKeeper.OnScoreChange += OnScoreChanged;
        }

        private void OnScoreChanged(object sender, int e)
        {
            textScore.text = $"{e}";
        }
    }
}