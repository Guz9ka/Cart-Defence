using UnityEngine;

public class MaxHealth_Setter : MonoBehaviour
{
    private const int DefaultMaxHealth = 100;
    
    private Health_Component _healthComponent;

    protected virtual int TryGetMaxHealth()
    {
        return DefaultMaxHealth;
    }
    
    private void TrySetMaximumHealth(int value)
    {
        if (!_healthComponent) return;
        
        _healthComponent.TrySetMaxHealth(value);
    }

    private void Start()
    {
        if (!TryGetComponent(out _healthComponent)) return;

        var maxHealthValue = TryGetMaxHealth();
        TrySetMaximumHealth(maxHealthValue);
        
        ObjectDestroyer.TryDestroyObject(this);
    }
}
