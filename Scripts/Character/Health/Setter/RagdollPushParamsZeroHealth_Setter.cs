using UnityEngine;

public class RagdollPushParamsZeroHealth_Setter : MonoBehaviour
{
    [SerializeField] private RagdollParams ragdollParams;

    private void Awake()
    {
        if (!ragdollParams)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        if (!TryGetComponent(out OnZeroHealth_EventHandler zeroHealthEventHandler))
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        zeroHealthEventHandler.SetRagdollKnockbackForce(ragdollParams.PushForce);
        zeroHealthEventHandler.SetRagdollPushForceMode(ragdollParams.PushForceMode);
    }
}
