using TankU.Module.Base;

namespace TankU.Message
{
    public struct UpdateGameState
    {
        public UpdateGameState(GameState gameState)
        {
            GameState = gameState;
        }

        private GameState GameState { get; }
    }
}