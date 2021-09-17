using System;
using UnityEngine;

// Класс описывает здоровье объекта и взаимодействие с ним.
public class Health_Component : MonoBehaviour
{
    public event EventHandler OnZeroHealth;
    public event EventHandler OnDamageApplied;
    
    public int CurrentHealth { get; private set; }
    public int MAXHealth { get; private set; } = 100;
    
    protected bool IsAlive = true;

    public virtual void TryApplyDamage(int amount)
    {
        if (!IsAlive) return;
        
        var changedHp = CurrentHealth - amount;
        CurrentHealth = changedHp < 0 ? 0 : changedHp;
        
        OnDamageApplied?.Invoke(this, EventArgs.Empty);
        
        CheckIfDead();
    }

    #region Available Actions

    protected virtual void CheckIfDead()
    {
        if (CurrentHealth > 0) return;
        
        OnZeroHealth?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region Fields Setting

    public void TrySetMaxHealth(int value)
    {
        if (value <= 0) return;
        
        MAXHealth = value;
    }

    #endregion
    
    #region Available Actions

    public virtual void RestoreHealth()
    {
        CurrentHealth = MAXHealth;
    }

    #endregion
    
    #region Initialization

    protected virtual void Start()
    {
        OnZeroHealth += (sender, args) => IsAlive = false;
        RestoreHealth();
    }

    #endregion
}
