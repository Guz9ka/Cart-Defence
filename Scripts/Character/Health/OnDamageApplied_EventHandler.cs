using System;
using UnityEngine;

public class OnDamageApplied_EventHandler : MonoBehaviour
{
    protected Health_Component HealthComponent;    
    
    [SerializeField] private ParticleActivator_Component _particleActivatorComponent;

    protected virtual void HandleEvent(object s, EventArgs args)
    {
        if (!HealthComponent || !_particleActivatorComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _particleActivatorComponent.TryPlayParticles();
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (HealthComponent)
        {
            HealthComponent.OnDamageApplied -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        if (TryGetComponent(out HealthComponent))
        {
            HealthComponent.OnDamageApplied += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
            return;
        }
    }

    #endregion
}
