using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Params", menuName = "Scriptable Objects/Weapon Params/Weapon Params Raycast", order = 2)]
public class WeaponRaycastParams : WeaponParams
{
    [field:SerializeField] public int WeaponDamage { get; private set; }
    [field:SerializeField] public float ShootDistance { get; private set; }
    [field:SerializeField] public LayerMask TargetLayerMask { get; private set; }
}
