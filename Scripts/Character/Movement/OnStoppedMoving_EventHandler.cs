using System;
using UnityEngine;

public class OnStoppedMoving_EventHandler : MonoBehaviour
{
    private AnimationActivator_Component _animationActivatorComponent;
    
    private Movement_Component _movementComponent;
    
    private void HandleEvent(object s, EventArgs args)
    {
        if (!_animationActivatorComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _animationActivatorComponent.TriggerOnStoppedMoving();
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_movementComponent)
        {
            _movementComponent.OnStoppedMoving -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _movementComponent))
        {
            _movementComponent.OnStoppedMoving += HandleEvent;
        }

        TryGetComponent(out _animationActivatorComponent);
    }

    #endregion
}
