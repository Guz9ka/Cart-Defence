using UnityEngine;

public class PlayerWeaponAttacking_Controller : MonoBehaviour
{
    [SerializeField] private int enemiesCountToShoot;
    
    private Weapon_Component _weaponComponent;
    private NearbyEnemies_Data _nearbyEnemiesData;
    
    private void Update()
    {
        if (!_weaponComponent || !_nearbyEnemiesData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (_nearbyEnemiesData.EnemiesCount < enemiesCountToShoot) return;
        
        _weaponComponent.TriggerAttack();
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _weaponComponent);
        _nearbyEnemiesData = FindObjectOfType<NearbyEnemies_Data>();
    }

    #endregion
}
