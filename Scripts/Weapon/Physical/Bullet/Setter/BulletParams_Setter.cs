using UnityEngine;

public class BulletParams_Setter : MonoBehaviour
{
    private void Awake()
    {
        if (!TryGetComponent(out PhysicalBullet_Component physicalBulletComponent) || 
            !TryGetComponent(out PhysicalBullet_Data bulletData))
        {
            Debug.LogWarning("Missing Components");
            return;
        }
        
        physicalBulletComponent.SetLaunchForce(bulletData.BulletParams.LaunchForce);
        physicalBulletComponent.TrySetMissTime(bulletData.BulletParams.TimeBeforeMiss);
    }
}
