namespace TankU.Module.Base
{
    public enum PickingState
    {
        None,
        Start,
        Cancel,
        Finish
    }

    public enum InputLayout
    {
        KeyboardLeft,
        KeyboardRight,
        Gamepad
    }

    public enum GameState
    {
        None,
        Menu,
        Game,
        Pause,
        GameOver
    }

    public enum VisualEffectCategory
    {
        None,
        Explosion,
        Fire,
        MuzzleFlash,
        Trail
    }
}