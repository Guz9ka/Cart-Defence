using UnityEngine;

public class PlayerMovement_Controller : MonoBehaviour
{
    private LinearMovement_Component _movementComponent;
    
    private void Update()
    {
        if (!_movementComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        if (PlayerInput.HasActiveInput)
        {
            var originalMoveDirection = PlayerInput.MoveDirection;
            var newMoveDirection = new Vector3(originalMoveDirection.x, 0, originalMoveDirection.y);
        
            _movementComponent.TryMove(newMoveDirection);
            _movementComponent.NotifyMoving();
        }
        else
        {
            _movementComponent.NotifyStoppedMoving();
        }
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _movementComponent);
    }

    #endregion
}
