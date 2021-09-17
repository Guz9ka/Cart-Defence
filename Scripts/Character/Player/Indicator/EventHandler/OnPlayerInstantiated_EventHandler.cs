using UnityEngine;

public class OnPlayerInstantiated_EventHandler : MonoBehaviour
{
    private VirtualCameraFollowedTransform_Component[] _cameraFollowTransformComponents;
    
    private void HandleEvent(object s, PlayerIndicatorEventArgs args)
    {
        TrySetPlayerTransformData(args);
        TrySetPlayerTransformInCameras(args.PlayerIndicator.transform);
    }

    #region Available Actions

    private static void TrySetPlayerTransformData(PlayerIndicatorEventArgs args)
    {
        if (!args.PlayerIndicator)
        {
            Debug.LogWarning("Missing components");
        }

        if (args.PlayerIndicator)
        {
            PlayerPosition_Data.TrySetPlayerTransform(args.PlayerIndicator.transform);
        }
    }

    private void TrySetPlayerTransformInCameras(Transform playerTransform)
    {
        if (_cameraFollowTransformComponents == null || _cameraFollowTransformComponents.Length <= 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        foreach (var selectedTransformComponent in _cameraFollowTransformComponents)
        {
            if (!selectedTransformComponent)
            {
                Debug.LogWarning("Missing components");
                return;
            }
            
            selectedTransformComponent.TrySetFollowTransform(playerTransform);
        }
    }

    #endregion

    #region State Change Reactions

    private void OnDisable()
    {
        Player_Indicator.OnPlayerInstantiated -= HandleEvent;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        _cameraFollowTransformComponents = FindObjectsOfType<VirtualCameraFollowedTransform_Component>();
        Player_Indicator.OnPlayerInstantiated += HandleEvent;
    }

    #endregion
}
