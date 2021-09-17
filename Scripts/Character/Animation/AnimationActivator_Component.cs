using UnityEngine;

public class AnimationActivator_Component : MonoBehaviour
{
    private Animator _animator;

    #region Floats

    public void SetMoveSpeed(float newValue)
    {
        TrySetFloat(Globals.FloatMoveSpeed, newValue);
    }
    
    public void SetMoveSpeedWithWeapon(float newValue)
    {
        TrySetFloat(Globals.FloatMoveSpeedWithWeapon, newValue);
    }

    #endregion

    #region Triggers

    public virtual void TriggerOnStartedMoving()
    {
        TrySetAnimationTrigger(Globals.TriggerOnStartedMoving);
    }

    public virtual void TriggerOnStoppedMoving()
    {
        TrySetAnimationTrigger(Globals.TriggerOnStoppedMoving);
    }

    public virtual void TriggerOnDied()
    {
        TrySetAnimationTrigger(Globals.TriggerOnDied);
    }

    #endregion

    #region Bools

    public virtual void SetBoolIsShooting(bool value)
    {
        TrySetBool(Globals.BoolIsShooting, value);
    }

    #endregion

    #region Available Actions

    public void TryStopAllAnimations()
    {
        if (!_animator)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _animator.enabled = false;
    }
    
    private void TrySetAnimationTrigger(string triggerName)
    {
        if (!_animator)
        {
            Debug.LogWarning("Missing components");
            return;
        } 
        
        TryResetAllTriggers();
        _animator.SetTrigger(triggerName);
    }

    private void TrySetBool(string boolName, bool value)
    {
        if (!_animator)
        {
            Debug.LogWarning("Missing components");
            return;
        } 
        
        _animator.SetBool(boolName, value);
    }

    private void TrySetFloat(string floatName, float newValue)
    {
        if (!_animator)
        {
            Debug.LogWarning("Missing components");
            return;
        } 
        
        _animator.SetFloat(floatName, newValue);
    }

    #endregion
    
    #region Auxiliary

    private void TryResetAllTriggers()
    {
        if (!_animator)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        foreach (var param in _animator.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                if (param.name == Globals.BoolIsShooting) continue;
                
                _animator.ResetTrigger(param.name);
            }
        }
    }
    
    #endregion
    
    #region Initialization

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    #endregion
}
