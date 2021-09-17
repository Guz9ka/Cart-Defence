using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageParams_Setter : MonoBehaviour
{
    private void Awake()
    {
        if (!TryGetComponent(out CollisionDamager_ComponentController collisionDamager) || 
            !TryGetComponent(out PhysicalBullet_Data bulletData))
        {
            Debug.LogWarning("Missing Components");
            return;
        }
        
        collisionDamager.SetTargetLayerMask(bulletData.BulletParams.TargetLayer);
        collisionDamager.TrySetDamage(bulletData.BulletParams.DamageForHit);
    }
}
