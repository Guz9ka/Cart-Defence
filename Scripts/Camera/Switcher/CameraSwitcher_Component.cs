using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitcher_Component : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> cameras;

    private const int ActivePriority = 10;
    private const int InActivePriority = 1;
    
    public void SwitchCamera(int cameraID)
    {
        if (cameraID >= cameras.Count)
        {
            Debug.LogWarning("Index out of range");
            return;
        }

        foreach (var selectedCamera in cameras)
        {
            if (!selectedCamera) continue;

            if (selectedCamera == cameras[cameraID])
            {
                selectedCamera.Priority = ActivePriority;
            }
            else
            {
                selectedCamera.Priority = InActivePriority;
            }
        }
    }
}
