using System;
using UnityEngine;

public class PlayerFollowing_Component : Movement_Component
{
    public event EventHandler OnPlayerReached;

    public float StopFollowDistance { get; private set; }
    public float ContinueFollowDistance { get; private set; }
    
    private CharacterController _charController;
    
    public void TryFollowPlayer()
    {
        if (!IsActive) return;
        if (!_charController)
        {
            Debug.LogError("Missing components");
            return;
        }
        
        var motion = transform.forward * (MoveSpeed * Time.deltaTime);
        _charController.Move(motion);
    }

    public void TryLookOnPlayer()
    {
        if (!IsActive) return;
        if (!PlayerPosition_Data.PlayerTransform)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        // TODO replace with smooth rotation only on xz axis
        var playerPosition = PlayerPosition_Data.PlayerTransform.position;
        transform.LookAt(playerPosition);
    }

    #region Auxiliary

    public float TryGetDistanceToPlayer()
    {
        if (!PlayerPosition_Data.PlayerTransform)
        {
            Debug.LogWarning("Missing components");
            return 0;
        }
        
        var playerPosition = PlayerPosition_Data.PlayerTransform.position;
        var distanceToPlayer = VectorHelper.GetVectorsDistance(playerPosition, transform.position);
        
        return distanceToPlayer;
    }
    
    public void NotifyPlayerReached()
    {
        OnPlayerReached?.Invoke(this, EventArgs.Empty);
    }

    #endregion
    
    #region Fields Setting

    public void TrySetStopDistance(float amount)
    {
        if (StopFollowDistance < 0) return;
        
        StopFollowDistance = amount;
    }
    
    public void TrySetContinueDistance(float amount)
    {
        if (ContinueFollowDistance < 0) return;
        
        ContinueFollowDistance = amount;
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        TryLookOnPlayer();
    }

    private void Awake()
    {
        TryGetComponent(out _charController);
    }

    #endregion
}
