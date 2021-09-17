using UnityEngine;

public class PoolFillerParams_Setter : MonoBehaviour
{
    private void Awake()
    {
        if (!TryGetComponent(out WeaponPhysical_Component weaponComponent) || 
            !TryGetComponent(out BulletPoolFill_Controller fillController))
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        fillController.TrySetBulletToSpawn(weaponComponent.WeaponParams.PhysicalBulletComponent);
    }
}
