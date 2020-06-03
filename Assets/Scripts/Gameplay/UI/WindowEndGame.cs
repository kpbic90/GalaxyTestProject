using Gameplay.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class WindowEndGame : MonoBehaviour
    {
        [SerializeField] private Text textScore;

        public void Start()
        {
            textScore.text = $"Score: {GameScoreKeeper.Score}";
        }

        public void PlayAgain()
        {
            GameController.Instance.PlayAgain();
        }
    }
}