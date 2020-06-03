namespace Gameplay.Helpers
{
    public interface InputStrategy
    {
        float GetHorizontalMove(float currentPosition);

        bool IsStrategySwitchedPressed(out InputStrategy inputStrategy);

        bool IsFirePressed();
    }
}