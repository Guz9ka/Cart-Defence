using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Params", menuName = "Scriptable Objects/Bullet Params", order = 4)]
public class BulletParams : ScriptableObject
{
    [field: SerializeField] public int LaunchForce { get; private set; }
    [field: SerializeField] public float TimeBeforeMiss { get; private set; }
    
    [field: SerializeField] public LayerMask TargetLayer { get; private set; }
    [field: SerializeField] public int DamageForHit { get; private set; }
}
