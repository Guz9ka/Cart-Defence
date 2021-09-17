using UnityEngine;

public class CameraSwitcher_Controller : MonoBehaviour
{
    private CameraSwitcher_Component _cameraSwitcherComponent;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            _cameraSwitcherComponent.SwitchCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            _cameraSwitcherComponent.SwitchCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            _cameraSwitcherComponent.SwitchCamera(2);
        }
    }

    private void Awake()
    {
        TryGetComponent(out _cameraSwitcherComponent);
    }
}
