using System;
using UnityEngine;

public class GameState_Component : MonoBehaviour
{
    public event EventHandler<GameStateEventArgs> OnGameStateChanged;
    
    public GameState CurrentGameState { get; private set; }

    public void TryStartGame()
    {
        if (CurrentGameState != GameState.Warmup) return;

        CurrentGameState = GameState.Running;
        NotifyGameStateChange(GameState.Running);
    }
    
    public void TryWinGame()
    {
        if (CurrentGameState != GameState.Running) return;

        CurrentGameState = GameState.Win;
        NotifyGameStateChange(GameState.Win);
    }

    public void TryLoseGame()
    {
        if (CurrentGameState != GameState.Running) return;

        CurrentGameState = GameState.Lose;
        NotifyGameStateChange(GameState.Lose);
    }

    #region Auxiliary

    private void NotifyGameStateChange(GameState newGameState)
    {
        var args = new GameStateEventArgs
        {
            GameState = newGameState
        };
        OnGameStateChanged?.Invoke(this, args);
    }

    #endregion
}

