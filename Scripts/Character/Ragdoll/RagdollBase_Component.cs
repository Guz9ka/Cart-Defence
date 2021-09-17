using System.Collections.Generic;
using UnityEngine;

public class RagdollBase_Component : MonoBehaviour
{
    [SerializeField] protected GameObject SkinWithRagdoll;
    [SerializeField] protected bool FreezeOnStart;

    protected List<Rigidbody> RagdollParts;

    public virtual void TryChangeRagdollState(RigidbodyConstraints newState)
    {
        foreach (var selectedRigidbody in RagdollParts)
        {
            if (!selectedRigidbody) continue;
            
            selectedRigidbody.constraints = newState;
        }
    }

    public virtual void TryAddForce(Vector3 direction, int force, ForceMode desiredForceMode)
    {
        var desiredPushDirection = direction * force;
        
        foreach (var selectedRigidbody in RagdollParts)
        {
            if (!selectedRigidbody) continue;
            
            selectedRigidbody.AddForce(desiredPushDirection, desiredForceMode);
        }
    }

    #region Auxiliary
    
    protected virtual void TryGetRagdollsFromSkin()
    {
        if (!SkinWithRagdoll)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var rigidbodiesFromSkin = SkinWithRagdoll.GetComponentsInChildren<Rigidbody>();
        if (rigidbodiesFromSkin == null || rigidbodiesFromSkin.Length <= 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedRigidbody in rigidbodiesFromSkin)
        {
            RagdollParts.Add(selectedRigidbody);
        }
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        RagdollParts = new List<Rigidbody>();
        TryGetRagdollsFromSkin();
        
        if (FreezeOnStart)
        {
            TryChangeRagdollState(RigidbodyConstraints.FreezeAll);
        }
    }

    #endregion
}
