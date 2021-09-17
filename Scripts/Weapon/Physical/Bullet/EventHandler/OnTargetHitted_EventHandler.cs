using System;
using UnityEngine;

public class OnTargetHitted_EventHandler : MonoBehaviour
{
    private ParticleActivator_Component _particleActivatorComponent;
    
    private PhysicalBullet_Component _physicalBulletComponent;
    
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
        if (_physicalBulletComponent)
        {
            _physicalBulletComponent.OnHittedTarget -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _physicalBulletComponent))
        {
            _physicalBulletComponent.OnHittedTarget += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
        }

        TryGetComponent(out _particleActivatorComponent);
    }

    #endregion
}
