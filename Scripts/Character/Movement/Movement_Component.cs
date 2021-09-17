using System;
using UnityEngine;

public class Movement_Component : MonoBehaviour, IActivatedByGameStateObject
{
    public event EventHandler OnStartedMoving;
    public event EventHandler OnStoppedMoving;
    
    public bool IsActive { get; set; }
    
    protected float MoveSpeed;

    #region Auxiliary

    public void NotifyMoving()
    {
        OnStartedMoving?.Invoke(this, EventArgs.Empty);
    }
    
    public void NotifyStoppedMoving()
    {
        OnStoppedMoving?.Invoke(this, EventArgs.Empty);
    }

    #endregion
    
    #region Fields Setting

    public void SetMovementSpeed(float amount)
    {
        MoveSpeed = amount;
    }

    public void OnGameStateChanged(GameState newState)
    {
        var newActivityState = GameStateCaster.CastGameStateToActivityState(newState);
        TryChangeActivityState(newActivityState);
    }

    public void TryChangeActivityState(bool newState)
    {
        IsActive = newState;
    }
    
    #endregion
}
