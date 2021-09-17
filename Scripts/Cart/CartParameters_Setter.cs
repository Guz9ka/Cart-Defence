using UnityEngine;

public class CartParameters_Setter : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out Cart_Data cartData);
        TryGetComponent(out CartMovement_Component cartMovementComponent);
        TryGetComponent(out NearbyPlayerSearch_Component playerSearchComponent);
        TryGetComponent(out CartMovement_Controller cartMovementController);
        
        if (cartData && cartData.CartParams && cartMovementComponent && playerSearchComponent && cartMovementController)
        {
            var defaultSpeedChangeTime = cartData.CartParams.DefaultSpeedChangeTime;
            var activationRadius = cartData.CartParams.ActivationRadius;
            
            cartMovementComponent.TrySetDeafultSpeedChangeTime(defaultSpeedChangeTime);
            playerSearchComponent.TrySetActivationRadius(activationRadius);
            
            cartMovementController.SetSearchDistance(cartData.CartParams.ObstacleSearchDistance);
            cartMovementController.SetObstacleLayerMask(cartData.CartParams.ObstacleLayerMask);
            
            cartMovementController.TrySetColliderSize(cartData.CartParams.SearchColliderSize);
        }
        else
        {
            Debug.LogWarning("Missing components");
        }
    }
}
