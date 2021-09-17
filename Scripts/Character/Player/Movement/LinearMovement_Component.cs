using UnityEngine;

public class LinearMovement_Component : Movement_Component
{
    private CharacterController _charController;
    
    public void TryMove(Vector3 direction)
    {
        if (!_charController)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (!IsActive) return;

        var movementDistance = direction * (MoveSpeed * Time.deltaTime);
        _charController.Move(movementDistance);
    }
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _charController);
    }

    #endregion
}
