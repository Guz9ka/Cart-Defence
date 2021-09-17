using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Params Bullet", menuName = "Scriptable Objects/Weapon Params/Weapon Params Bullet", order = 1)]
public class WeaponParamsPhysical : WeaponParams
{
    [field: SerializeField] public PhysicalBullet_Component PhysicalBulletComponent { get; private set; }
    [field: SerializeField] public Vector3 BulletSpreadRange { get; private set; }
}
