using Cinemachine;
using UnityEngine;

public class VirtualCameraFollowedTransform_Component : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    
    public void TrySetFollowTransform(Transform transformToFollow)
    {
        if (!_virtualCamera || !transformToFollow)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _virtualCamera.m_Follow = transformToFollow;
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _virtualCamera);
    }

    #endregion
}
