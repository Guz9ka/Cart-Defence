using System;
using UnityEngine;
using UnityEngine.UI;

public class OnDamageAppliedPlayer_EventHandler : OnDamageApplied_EventHandler
{
    private Slider _hpBar;

    protected override void HandleEvent(object s, EventArgs args)
    {
        base.HandleEvent(s, args);

        if (!_hpBar)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _hpBar.value = HealthComponent.CurrentHealth;
    }

    #region Auxiliary

    private void TryInitializeHealthBar()
    {
        if (!HealthComponent || !_hpBar) return;
        
        _hpBar.maxValue = HealthComponent.MAXHealth;
        _hpBar.minValue = 0;
        _hpBar.value = HealthComponent.CurrentHealth;
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        TryInitializeHealthBar();
    }

    protected override void Awake()
    {
        base.Awake();

        _hpBar = GetComponentInChildren<Slider>();
    }

    #endregion
}
