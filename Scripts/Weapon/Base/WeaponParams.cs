using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Params", menuName = "Scriptable Objects/Weapon Params/Weapon Params Base", order = 0)]
public class WeaponParams : ScriptableObject
{
    [field:SerializeField] public float ShootTime { get; private set; }
}
