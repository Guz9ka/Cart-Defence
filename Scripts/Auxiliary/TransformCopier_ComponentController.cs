using UnityEngine;

public class TransformCopier_ComponentController : MonoBehaviour
{
    [Header("Copy Parameters")] 
    [SerializeField] private Transform transformToCopy;

    [Header("Offset")] 
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    protected virtual void Update()
    {
        CopyPosition();
        CopyRotation();
    }

    #region Available Actions

    protected virtual void CopyPosition()
    {
        if (!transformToCopy)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        transform.position = transformToCopy.position; //+ positionOffset;
    } 
    
    protected virtual void CopyRotation()
    {
        if (!transformToCopy)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        // var desiredRotation = transformToCopy.rotation.eulerAngles + rotationOffset;
        // transform.rotation = Quaternion.Euler(desiredRotation);

        transform.rotation = transformToCopy.rotation;
    } 

    #endregion
    
    #region Fields Setting

    public void SetPositionOffset(Vector3 newOffset)
    {
        positionOffset = newOffset;
    }
    
    public void SetRotationOffset(Vector3 newOffset)
    {
        rotationOffset = newOffset;
    }

    #endregion
}
