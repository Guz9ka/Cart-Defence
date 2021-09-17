using System;

public static class GameStateCaster
{
    public static bool CastGameStateToActivityState(GameState gameState)
    {
        return gameState switch
        {
            GameState.Warmup => false,
            GameState.Running => true,
            GameState.Win => false,
            GameState.Lose => false,
            _ => throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null)
        };
    }
}
