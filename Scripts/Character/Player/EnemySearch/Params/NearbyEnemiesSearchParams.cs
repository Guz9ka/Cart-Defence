using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Search Params", menuName = "Scriptable Objects/Enemy Search Params", order = 3)]
public class NearbyEnemiesSearchParams : ScriptableObject
{
    [field: SerializeField] public float SearchDistance { get; private set; }
}
