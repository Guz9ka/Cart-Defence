using UnityEngine;

public class LookParameters_Setter : MonoBehaviour
{
    private void Awake()
    {
        var playerData = GetComponentInParent<Player_Data>();
        TryGetComponent(out LookAtNearestEnemy_ComponentController lookAtEnemyComponent);
        
        if (playerData && playerData.PlayerParams && lookAtEnemyComponent)
        {
            var rotationSpeed = playerData.PlayerParams.RotationSpeed;
            var lookDistance = playerData.PlayerParams.LookAtEnemyDistance;
            
            lookAtEnemyComponent.SetRotationSpeed(rotationSpeed);
            lookAtEnemyComponent.TrySetLookDistance(lookDistance);
        }
        else
        {
            Debug.LogWarning("Missing components");
        }
    }
}
