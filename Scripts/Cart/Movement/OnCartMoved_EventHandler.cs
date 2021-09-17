using System;
using UnityEngine;

public class OnCartMoved_EventHandler : MonoBehaviour
{
    private ParticleActivator_Component _particleActivatorComponent;
    
    private CartMovement_Component _cartMovementComponent;
    
    private void HandleEvent(object s, EventArgs args)
    {
        if (!_particleActivatorComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _particleActivatorComponent.TryPlayParticles();
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_cartMovementComponent)
        {
            _cartMovementComponent.OnCartMoved -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _cartMovementComponent))
        {
            _cartMovementComponent.OnCartMoved += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
            return;
        }

        TryGetComponent(out _particleActivatorComponent);
    }

    #endregion
}
