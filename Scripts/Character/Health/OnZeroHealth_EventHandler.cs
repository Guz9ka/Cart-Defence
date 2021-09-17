using System;
using UnityEngine;

public class OnZeroHealth_EventHandler : MonoBehaviour
{
    [SerializeField] private ParticleActivator_Component particleActivatorComponent;
    
    private AnimationActivator_Component _animationActivatorComponent;
    private Weapon_Component _weaponComponent;
    private ChildrenDetacher_Component _childrenDetacherComponent;
    private RagdollBase_Component _ragdollComponent;

    private int _ragdollKnockbackForce;
    private ForceMode _ragdollPushForceMode;
    
    private Health_Component _healthComponent;

    protected virtual void HandleEvent(object s, EventArgs args)
    {
        if (!particleActivatorComponent || !_animationActivatorComponent || !_weaponComponent || 
            !_childrenDetacherComponent || !_ragdollComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        particleActivatorComponent.TryPlayParticles();
        _weaponComponent.DisableWeapon();
        _animationActivatorComponent.TryStopAllAnimations();
        
        _childrenDetacherComponent.TryDetachChildren();
        
        _ragdollComponent.TryChangeRagdollState(RigidbodyConstraints.None);
        var pushDirection = transform.forward * -1;
        _ragdollComponent.TryAddForce(pushDirection, _ragdollKnockbackForce, _ragdollPushForceMode);
        
        ObjectDestroyer.TryDestroyObject(gameObject);
    }

    #region Fields Setting

    public void SetRagdollKnockbackForce(int newForce)
    {
        _ragdollKnockbackForce = newForce;
    }
    
    public void SetRagdollPushForceMode(ForceMode newForceMode)
    {
        _ragdollPushForceMode = newForceMode;
    }

    #endregion
    
    #region State Change Reactions

    private void OnDisable()
    {
        if (_healthComponent)
        {
            _healthComponent.OnZeroHealth -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        if (TryGetComponent(out _healthComponent))
        {
            _healthComponent.OnZeroHealth += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
            return;
        }

        TryGetComponent(out _animationActivatorComponent);
        TryGetComponent(out _childrenDetacherComponent);
        TryGetComponent(out _ragdollComponent);
        
        _weaponComponent = GetComponentInChildren<Weapon_Component>();
    }

    #endregion
}
