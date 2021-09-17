using UnityEngine;

[CreateAssetMenu(fileName = "Money Drop Params", menuName = "Scriptable Objects/Money/Money Drop Params", order = 0)]
public class MoneyDropParams : ScriptableObject
{
    [field: SerializeField] public GameObject MoneyPrefab { get; private set; }
    [field:SerializeField] public MinMaxInt DropAmount { get; private set; }
    
    [field:SerializeField] public MinMaxVector3 DropDirectionsRange { get; private set; }
}
