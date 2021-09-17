using System;
using UnityEngine;

public class OnShot_EventHandler : MonoBehaviour
{
    private ParticleActivator_Component _particleActivatorComponent;
    
    private Weapon_Component _weaponComponent;

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
        if (_weaponComponent)
        {
            _weaponComponent.OnShot -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _weaponComponent))
        {
            _weaponComponent.OnShot += HandleEvent;
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
