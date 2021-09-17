using System;
using System.Collections;
using UnityEngine;

public class Weapon_Component : MonoBehaviour, IActivatedByGameStateObject
{
    public event EventHandler OnShot;

    public bool IsActive { get; set; }
    public bool IsCanShoot { get; protected set; } = true;

    [SerializeField] protected Transform shootStartTransform;

    public virtual void TriggerAttack()
    {
    }

    #region Available Actions

    public void DisableWeapon()
    {
        StopAllCoroutines();
        IsCanShoot = false;
    }

    protected IEnumerator DisableShooting(float disableTime)
    {
        IsCanShoot = false;

        yield return new WaitForSeconds(disableTime);

        IsCanShoot = true;
    }

    #endregion

    #region Fields Setting

    public void OnGameStateChanged(GameState newState)
    {
        IsActive = GameStateCaster.CastGameStateToActivityState(newState);
    }

    #endregion

    #region Auxiliary

    protected void NotifyOnShot()
    {
        OnShot?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}