using UnityEngine;

[CreateAssetMenu(fileName = "Player Params", menuName = "Scriptable Objects/Player Params", order = 0)]
public class PlayerParams : CharacterParams
{
    [field: SerializeField] public float LookAtEnemyDistance { get; private set; }
    [field: SerializeField] public int RotationSpeed { get; private set; }
}
