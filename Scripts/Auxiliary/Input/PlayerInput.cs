using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static Vector2 MoveDirection { get; private set; }
    public static float MoveSpeed { get; private set; }
    public static bool HasActiveInput { get; private set; }
    
    private DynamicJoystick _dynamicJoystick;

    private void Update()
    {
        MoveDirection = TryGetJoystickInput();
        MoveSpeed = GetMoveSpeed();
        HasActiveInput = TryGetActiveInput();
    }

    #region Available Actions

    private float GetMoveSpeed()
    {
        var absDirectionX = Mathf.Abs(MoveDirection.x);
        var absDirectionY = Mathf.Abs(MoveDirection.y);

        if (absDirectionX >= absDirectionY)
        {
            return MoveDirection.x;
        }

        return MoveDirection.y;
    }
    
    private Vector2 TryGetJoystickInput()
    {
        if (!_dynamicJoystick)
        {
            Debug.LogWarning("Missing components");
            return Vector2.zero;
        }

        return _dynamicJoystick.Direction;
    }

    private bool TryGetActiveInput()
    {
        if (!_dynamicJoystick)
        {
            Debug.LogWarning("Missing components");
            return false;
        }

        var isInputNotZero = _dynamicJoystick.Direction.x != 0 || _dynamicJoystick.Direction.y != 0;

        return isInputNotZero;
    }

    #endregion

    #region Fields Setting

    public void TrySetJoystick(DynamicJoystick newJoystick)
    {
        if (!newJoystick)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _dynamicJoystick = newJoystick;
    }

    #endregion
}
