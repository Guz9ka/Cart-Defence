using System;
using UnityEngine;

public class CollisionDamager_ComponentController : MonoBehaviour
{
    public event EventHandler OnCollisionDetected;
    
    private int _damageOnHit;
    private LayerMask _targetLayerMask;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Health_Component targetHealthComponent)) return;

        targetHealthComponent.TryApplyDamage(_damageOnHit);
        NotifyCollisionDetected();
    }

    #region Auxiliary

    private void NotifyCollisionDetected()
    {
        OnCollisionDetected?.Invoke(this, EventArgs.Empty);
    }

    #endregion
    
    #region Fields Setting

    public void TrySetDamage(int amount)
    {
        if (amount < 0) return;

        _damageOnHit = amount;
    }

    public void SetTargetLayerMask(LayerMask layerMask)
    {
        _targetLayerMask = layerMask;
    }

    #endregion
}
