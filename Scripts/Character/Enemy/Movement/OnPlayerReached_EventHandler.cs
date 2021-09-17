using System;
using UnityEngine;

public class OnPlayerReached_EventHandler : MonoBehaviour
{
    private Weapon_Component _weaponComponent;
    private PlayerFollowing_Component _playerFollowingComponent;

    private void HandleEvent(object s, EventArgs args)
    {
        if (!_weaponComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _weaponComponent.TriggerAttack();
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_playerFollowingComponent)
        {
            _playerFollowingComponent.OnPlayerReached -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _playerFollowingComponent))
        {
            _playerFollowingComponent.OnPlayerReached += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _weaponComponent = GetComponentInChildren<Weapon_Component>();
    }

    #endregion
}
