using UnityEngine;

public class PlayerMoveSpeed_Setter : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent(out Player_Data playerData) && playerData.PlayerParams 
                                                        && TryGetComponent(out LinearMovement_Component playerMovementComponent))
        {
            var moveSpeed = playerData.PlayerParams.MoveSpeed;
            
            playerMovementComponent.SetMovementSpeed(moveSpeed);
        }
        
        ObjectDestroyer.TryDestroyObject(this);
    }
}
