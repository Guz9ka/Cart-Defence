using System;
using UnityEngine;

public class PlayerAnimationSpeed_Setter : MonoBehaviour
{
    private AnimationActivator_Component _animationComponent;
    
    private void Update()
    {
        TrySetMoveSpeed();
    }

    private void TrySetMoveSpeed()
    {
        if (!_animationComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var moveSpeed = Mathf.Abs(PlayerInput.MoveSpeed);
        _animationComponent.SetMoveSpeed(moveSpeed);
    }

    private void TrySetMoveWithWeaponSpeed()
    {
        if (!_animationComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var moveSpeedWithWeapon = PlayerInput.MoveSpeed;
        _animationComponent.SetMoveSpeedWithWeapon(moveSpeedWithWeapon);
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _animationComponent);
    }

    #endregion
}
