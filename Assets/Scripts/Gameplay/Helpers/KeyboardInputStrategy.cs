using UnityEngine;

namespace Gameplay.Helpers
{
    public class KeyboardInputStrategy : InputStrategy
    {
        public float GetHorizontalMove(float currentPosition)
        {
            return Input.GetAxis("Horizontal");
        }

        public bool IsFirePressed()
        {
            return Input.GetKey(KeyCode.Space);
        }

        public bool IsStrategySwitchedPressed(out InputStrategy inputStrategy)
        {
            inputStrategy = new MouseInputStrategy();
            return Input.GetKey(KeyCode.Tab);
        }
    }
}