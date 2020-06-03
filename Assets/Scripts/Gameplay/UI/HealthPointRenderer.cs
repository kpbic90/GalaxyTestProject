using UnityEngine;

namespace Gameplay.UI
{
    public class HealthPointRenderer : MonoBehaviour
    {
        [SerializeField] private GameObject spriteHealthPoint;

        public void PopHealth(bool isEmpty)
        {
            spriteHealthPoint.SetActive(isEmpty);
        }
    }
}