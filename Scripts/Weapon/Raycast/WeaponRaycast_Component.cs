using System.Collections;
using UnityEngine;

public class WeaponRaycast_Component : Weapon_Component
{
    [SerializeField] private WeaponRaycastParams weaponParams;

    public override void TriggerAttack()
    {
        if (!IsCanShoot || !IsActive) return;
        
        var foundHealthComponent = TryGetHealth();
        StartCoroutine(TryAttackFoundHealth(foundHealthComponent));
    }

    #region Available Actions

    protected virtual IEnumerator TryAttackFoundHealth(Health_Component healthComponent)
    {
        if (!IsCanShoot || !healthComponent || !weaponParams) yield break;

        IsCanShoot = false;

        healthComponent.TryApplyDamage(weaponParams.WeaponDamage);
        NotifyOnShot();
        
        yield return new WaitForSeconds(weaponParams.ShootTime);
        
        IsCanShoot = true;
    }

    #endregion
    
    #region Auxiliary

    private Health_Component TryGetHealth()
    {
        if (!shootStartTransform || !weaponParams)
        {
            Debug.LogWarning("Missing components");
            return null;
        }
        var startPosition = shootStartTransform.position;
        var direction = shootStartTransform.forward;
        
        var foundHealthComponent = RaycastHelper.TryFindObject<Health_Component>(startPosition, direction, 
            weaponParams.ShootDistance, weaponParams.TargetLayerMask);

        return foundHealthComponent;
    }

    #endregion
}
