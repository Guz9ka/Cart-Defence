using System;
using UnityEngine;

public class OnZeroHealthEnemy_EventHandler : OnZeroHealth_EventHandler
{
    private MoneyDrop_Component _moneyDropComponent;
    
    protected override void HandleEvent(object s, EventArgs args)
    {
        if (!_moneyDropComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _moneyDropComponent.TryDropMoney();
        
        base.HandleEvent(s, args);
    }

    #region Initialization

    protected override void Awake()
    {
        base.Awake();

        _moneyDropComponent = GetComponentInChildren<MoneyDrop_Component>();
    }

    #endregion
}
