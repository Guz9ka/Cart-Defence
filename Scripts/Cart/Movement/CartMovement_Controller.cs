using UnityEngine;

public class CartMovement_Controller : MonoBehaviour
{
    private NearbyPlayerSearch_Component _playerSearchComponent;
    private CartMovement_Component _cartMovementComponent;

    private LayerMask _obstacleLayerMask;
    private float _searchDistance;
    private Vector3 _searchColliderSize;

    private void Update()
    {
        if (!_cartMovementComponent || !_playerSearchComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        var foundPlayer = _playerSearchComponent.TryGetPlayerNearby();
        var obstacleInFront = TryGetObstacleInFront();
        
        if (foundPlayer && !obstacleInFront)
        {
            _cartMovementComponent.ChangeCartSpeed(SpeedChangeType.SpeedUp);
            _cartMovementComponent.NotifyCartMoved();
        }
        else
        {
            _cartMovementComponent.ChangeCartSpeed(SpeedChangeType.SpeedDown);
        }
    }

    #region Available Actions

    private bool TryGetObstacleInFront()
    {
        var startPosition = transform.position;
        var direction = transform.forward;

        return Physics.BoxCast(startPosition, _searchColliderSize, direction, 
            Quaternion.identity, _searchDistance, _obstacleLayerMask);
    }

    #endregion

    #region Fields Setting

    public void SetObstacleLayerMask(LayerMask newTargetMask)
    {
        _obstacleLayerMask = newTargetMask;
    }

    public void TrySetColliderSize(Vector3 newSize)
    {
        _searchColliderSize = newSize;
    }
    
    public void SetSearchDistance(float newSearchDistance)
    {
        _searchDistance = newSearchDistance;
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        TryGetComponent(out _playerSearchComponent);
        if (TryGetComponent(out _cartMovementComponent))
        {
            _cartMovementComponent.InitializeCart();
        }
    }

    #endregion
}
