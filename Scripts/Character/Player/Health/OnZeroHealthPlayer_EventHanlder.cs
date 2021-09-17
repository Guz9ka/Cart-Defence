using System;
using UnityEngine;

public class OnZeroHealthPlayer_EventHanlder : OnZeroHealth_EventHandler
{
    private GameState_Component _gameStateComponent;

    protected override void HandleEvent(object s, EventArgs args)
    {
        if (!_gameStateComponent)
        {
            Debug.LogWarning("Missing components");
        }
    
        if (_gameStateComponent)
        {
            _gameStateComponent.TryLoseGame();
        }
        
        base.HandleEvent(s, args);
    }

    #region Initialization

    protected override void Awake()
    {
        base.Awake();
        
        _gameStateComponent = FindObjectOfType<GameState_Component>();
    }

    #endregion
}
