using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SWS;
using UnityEngine;

public class CartMovement_Component : MonoBehaviour
{
    public event EventHandler OnCartMoved;
    public float CurrentCartSpeed { get; private set; }
    
    public float DefaultSpeedChangeTime { get; private set; }
    
    private float _originalCartSpeed;
    
    // Classes
    private SpeedChangeType _currentSpeedChangeType;
    private TweenerCore<float, float, FloatOptions> _speedChangeCartTween;
    
    private SplineMove _cartMovement;

    public void ChangeCartSpeed(SpeedChangeType speedChangeType)
    {
        ChangeCartSpeed(speedChangeType, DefaultSpeedChangeTime);
    }
    
    public void ChangeCartSpeed(SpeedChangeType speedChangeType, float changeTime)
    {
        switch (speedChangeType)
        {
            case SpeedChangeType.SpeedUp:
                TrySpeedUpCart(changeTime);
                break;
            case SpeedChangeType.SpeedDown:
                TrySpeedDownCart(changeTime);
                break;
        }
    }
    
    #region Avaiable Actions

    private void TrySpeedUpCart(float changeTime)
    {
        if (!_cartMovement)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (!TryKillSpeedTween(SpeedChangeType.SpeedUp)) return;

        _currentSpeedChangeType = SpeedChangeType.SpeedUp;
        
        CurrentCartSpeed = _cartMovement.speed;
        _speedChangeCartTween = DOTween.To(() => CurrentCartSpeed, x => CurrentCartSpeed = x, 
            _originalCartSpeed, changeTime).OnUpdate(TryUpdateCartSpeed);
    }
    
    private void TrySpeedDownCart(float changeTime)
    {
        if (!_cartMovement)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (!TryKillSpeedTween(SpeedChangeType.SpeedDown)) return;

        _currentSpeedChangeType = SpeedChangeType.SpeedDown;
        
        CurrentCartSpeed = _cartMovement.speed;
        _speedChangeCartTween = DOTween.To(() => CurrentCartSpeed, x => CurrentCartSpeed = x, 
            0, changeTime).OnUpdate(TryUpdateCartSpeed);
    }
    
    private void TryUpdateCartSpeed()
    {
        if (!_cartMovement)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _cartMovement.ChangeSpeed(CurrentCartSpeed);
    }

    #endregion
    
    #region Auxiliary
    
    public void NotifyCartMoved()
    {
        OnCartMoved?.Invoke(this, EventArgs.Empty);
    }

    private bool TryKillSpeedTween(SpeedChangeType requiredSpeedChangeType)
    {
        if (_speedChangeCartTween == null) return true;
        if (_currentSpeedChangeType == requiredSpeedChangeType) return false;

        _speedChangeCartTween.Kill();

        return true;
    }

    #endregion
    
    #region Fields Setting

    public void TrySetDeafultSpeedChangeTime(float amount)
    {
        if (amount < 0) return;

        DefaultSpeedChangeTime = amount;
    }

    #endregion

    #region Initialization
    
    public void InitializeCart()
    {
        if (!_cartMovement)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _cartMovement.StartMove();
        _originalCartSpeed = _cartMovement.speed;

        TrySpeedDownCart(0);
    }
    
    private void Awake()
    {
        TryGetComponent(out _cartMovement);
    }

    #endregion
}
