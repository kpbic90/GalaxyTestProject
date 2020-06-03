using UnityEngine;

namespace Gameplay.Helpers
{
    public class MouseInputStrategy : InputStrategy
    {
        private const float step = 1f;

        public float GetHorizontalMove(float currentPosition)
        {
            var mousePosition = Input.mousePosition.x;
            var move = 0f;

            if (Mathf.Abs(mousePosition - currentPosition) > step)
                move = mousePosition > currentPosition ? step : -step;

            return move;
        }

        public bool IsFirePressed()
        {
            return Input.GetMouseButton(0);
        }

        public bool IsStrategySwitchedPressed(out InputStrategy inputStrategy)
        {
            inputStrategy = new KeyboardInputStrategy();
            return Input.GetMouseButton(1);
        }
    }
}