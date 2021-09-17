using UnityEngine;

public class CharacterParams : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
}
