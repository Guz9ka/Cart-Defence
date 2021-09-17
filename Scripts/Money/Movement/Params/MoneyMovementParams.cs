using UnityEngine;

[CreateAssetMenu(fileName = "Money Movement Params", menuName = "Scriptable Objects/Money/Money Movement Params", order = 1)]
public class MoneyMovementParams : ScriptableObject
{
    [field:SerializeField] public int DropForce { get; private set; }
    [field:SerializeField] public float TimeBeforeMovementToDestination { get; private set; }

    [field:SerializeField] public float MoveSpeed { get; private set; }
    [field:SerializeField] public float RotationSpeed { get; private set; }
    
    /// <summary>
    /// Для конвертирования экранной позиции в мировую нужно в ручную ставить отдаленность объекта
    /// </summary>
    [field:SerializeField] public Vector3 DestinationOffset { get; private set; }
    [field:SerializeField] public float StopDistance { get; private set; }
}
