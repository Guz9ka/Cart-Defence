using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Params", menuName = "Scriptable Objects/Enemy Params", order = 1)]
public class EnemyParams : CharacterParams
{
    [field: SerializeField] public float StopFollowDistance { get; private set; }
    [field: SerializeField] public float ContinueFollowDistance { get; private set; }
}
