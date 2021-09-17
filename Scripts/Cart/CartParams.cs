using UnityEngine;

[CreateAssetMenu(fileName = "Cart Params", menuName = "Scriptable Objects/Cart Params", order = 4)]
public class CartParams : ScriptableObject
{
    //[Header("Speed change")]
    [field:SerializeField] public float MovementSpeed { get; private set; }
    [field:SerializeField] public float DefaultSpeedChangeTime { get; private set; }
    
    //[Header("Activation")]
    [field:SerializeField] public float ActivationRadius { get; private set; }
    
    //[Header("Obstacle detection")]
    [field:SerializeField] public float ObstacleSearchDistance { get; private set; }
    [field:SerializeField] public Vector3 SearchColliderSize { get; private set; }
    [field:SerializeField] public LayerMask ObstacleLayerMask { get; private set; }
}
