using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponPhysical_Component : Weapon_Component
{
    [field: SerializeField] public WeaponParamsPhysical WeaponParams { get; protected set; }

    private BulletPool_Component _bulletPoolComponent;

    public override void TriggerAttack()
    {
        if (!IsCanShoot || !IsActive) return;

        LaunchProjectile();
    }

    #region Available Actions

    protected virtual void LaunchProjectile()
    {
        if (!shootStartTransform || !WeaponParams || !_bulletPoolComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        StartCoroutine(DisableShooting(WeaponParams.ShootTime));

        var spawnedBullet = _bulletPoolComponent.TryGetBulletFromStack(shootStartTransform);
        if (!spawnedBullet) return;

        var bulletSpread = GetBulletSpread();
        
        spawnedBullet.TryLaunch(shootStartTransform.forward + bulletSpread);
    }

    #endregion

    #region Auxiliary

    private Vector3 GetBulletSpread()
    {
        if (!WeaponParams)
        {
            Debug.LogWarning("Missing components");
            return Vector3.zero;
        }

        var spreadRange = WeaponParams.BulletSpreadRange;
        
        var randomX = Random.Range(-spreadRange.x, spreadRange.x);
        var randomY = Random.Range(-spreadRange.y, spreadRange.y);
        var randomZ = Random.Range(-spreadRange.z, spreadRange.z);
        
        return new Vector3(randomX, randomY, randomZ);
    }
    
    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _bulletPoolComponent);
    }

    #endregion
}
