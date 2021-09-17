using System;
using System.Collections;
using UnityEngine;

public class PhysicalBullet_Component : MonoBehaviour
{
    public event EventHandler<BulletEventArgs> OnHittedTarget;
    public event EventHandler<BulletEventArgs> OnMissedTarget;

    private int _launchForce;
    private float _timeBeforeMiss;
    
    private Rigidbody _rb;
    
    public void TryLaunch(Vector3 direction)
    {
        if (!_rb)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _rb.WakeUp();
        _rb.AddForce(direction * _launchForce);

        StartCoroutine(NotifyTargetMissedWithDelay());
    }
    
    public void TryStop()
    {
        if (!_rb)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _rb.Sleep();
    }

    #region Auxiliary

    public void NotifyTargetHitted()
    {
        var args = new BulletEventArgs
        {
            BulletComponent = this
        };
        OnHittedTarget?.Invoke(this, args);
    }

    private IEnumerator NotifyTargetMissedWithDelay()
    {
        yield return new WaitForSeconds(_timeBeforeMiss);
        
        var args = new BulletEventArgs
        {
            BulletComponent = this
        };
        OnMissedTarget?.Invoke(this, args);
    }
    
    #endregion
    
    #region Fields Setting

    public void SetLaunchForce(int newForce)
    {
        _launchForce = newForce;
    }

    public void TrySetMissTime(float value)
    {
        if (value < 0) return;

        _timeBeforeMiss = value;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _rb);
        OnHittedTarget += (sender, args) => StopAllCoroutines();
    }

    #endregion
}
