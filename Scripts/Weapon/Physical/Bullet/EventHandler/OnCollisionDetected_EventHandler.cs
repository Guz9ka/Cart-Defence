using System;
using UnityEngine;

public class OnCollisionDetected_EventHandler : MonoBehaviour
{
    private PhysicalBullet_Component _physicalBulletComponent;
    
    private CollisionDamager_ComponentController _collisionDamagerComponent;
    
    private void HandleEvent(object s, EventArgs args)
    {
        if (!_physicalBulletComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }   
        
        _physicalBulletComponent.NotifyTargetHitted();
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        if (_collisionDamagerComponent)
        {
            _collisionDamagerComponent.OnCollisionDetected -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _collisionDamagerComponent))
        {
            _collisionDamagerComponent.OnCollisionDetected += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
        }

        TryGetComponent(out _physicalBulletComponent);
    }

    #endregion
}
