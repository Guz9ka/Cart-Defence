using System;
using UnityEngine;

public class OnFinalPointReached_EventHandler : MonoBehaviour
{
    private ParticleActivator_Component _particleActivatorComponent;
    private GameState_Component _gameStateComponent;

    private CartFinalPointDetector_ComponentController _finalPointDetectorComponent;
    
    private void HandleEvent(object s, EventArgs args)
    {
        if (!_particleActivatorComponent || !_gameStateComponent) 
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _gameStateComponent.TryWinGame();
        _particleActivatorComponent.TryPlayParticles();
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_finalPointDetectorComponent)
        {
            _finalPointDetectorComponent.OnFinalPointReached -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _finalPointDetectorComponent))
        {
            _finalPointDetectorComponent.OnFinalPointReached += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        TryGetComponent(out _particleActivatorComponent);
        _gameStateComponent = FindObjectOfType<GameState_Component>();
    }

    #endregion
}
