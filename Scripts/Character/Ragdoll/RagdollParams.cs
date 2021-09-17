using UnityEngine;

[CreateAssetMenu(fileName = "Ragdoll Params", menuName = "Scriptable Objects/Ragdoll Params", order = 6)]
public class RagdollParams : ScriptableObject
{
    [field: SerializeField] public int PushForce { get; private set; }
    [field: SerializeField] public ForceMode PushForceMode { get; private set; }
}
