using UnityEngine;

public class SceneJoystick_Setter : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void TrySetDynamicJoystick()
    {
        if (!_playerInput)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var joystick = FindObjectOfType<DynamicJoystick>();
        _playerInput.TrySetJoystick(joystick);
    }
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _playerInput);
        TrySetDynamicJoystick();
    }

    #endregion
}
