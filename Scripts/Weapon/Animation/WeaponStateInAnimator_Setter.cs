using UnityEngine;

public class WeaponStateInAnimator_Setter : MonoBehaviour
{
    private AnimationActivator_Component _animationActivatorComponent;
    private NearbyEnemies_Data _enemiesData;

    private Weapon_Component _weaponComponent;

    private void LateUpdate()
    {
        if (!_weaponComponent || !_animationActivatorComponent || !_enemiesData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var enemyIsNearby = _enemiesData.EnemiesCount > 0;
        _animationActivatorComponent.SetBoolIsShooting(!_weaponComponent.IsCanShoot || enemyIsNearby);
    }

    #region Initiliaztion

    private void Awake()
    {
        _enemiesData = FindObjectOfType<NearbyEnemies_Data>();
        _weaponComponent = GetComponentInChildren<Weapon_Component>();
        TryGetComponent(out _animationActivatorComponent);
    }

    #endregion
}
