using System;
using UnityEngine;

public class OnDamageAppliedEnemy_EventHandler : OnDamageApplied_EventHandler
{
    private ColorSaturationChanger_Component _saturationChangerComponent;   
    
    protected override void HandleEvent(object s, EventArgs args)
    {
        base.HandleEvent(s, args);
        
        if (!_saturationChangerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _saturationChangerComponent.TryChangeSaturation(HealthComponent.CurrentHealth, 
            HealthComponent.MAXHealth);
    }

    #region Initialization

    protected override void Awake()
    {
        base.Awake();
        
        TryGetComponent(out _saturationChangerComponent);
    }

    #endregion
}
