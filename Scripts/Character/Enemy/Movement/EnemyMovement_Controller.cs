using UnityEngine;

public class EnemyMovement_Controller : MonoBehaviour, IActivatedByGameStateObject
{
    public bool IsActive { get; set; }
    
    private PlayerFollowing_Component _playerFollowingComponent;

    private bool _isStopped;
    
    private void Update()
    {
        if (!IsActive) return;
        
        TryCallLookOnPlayer();
        TryCallMovementAction();
    }

    #region Available Actions

    private void TryCallLookOnPlayer()
    {
        if (!_playerFollowingComponent)
        {
            Debug.LogError("Missing components");
            return;
        }

        _playerFollowingComponent.TryLookOnPlayer();
    }

    private void TryCallMovementAction()
    {
        if (!_playerFollowingComponent)
        {
            Debug.LogError("Missing components");
            return;
        }

        var distanceToPlayer = _playerFollowingComponent.TryGetDistanceToPlayer();

        var stopFollowDistance = _playerFollowingComponent.StopFollowDistance;
        var continueFollowDistance = _playerFollowingComponent.ContinueFollowDistance;

        if (distanceToPlayer > continueFollowDistance)
        {
            _isStopped = false;
            FollowPlayer();
        }
        else if (distanceToPlayer < stopFollowDistance)
        {
            _isStopped = true;
            StopFollow();
        }
        else
        {
            if (_isStopped)
            {
                StopFollow();
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    private void FollowPlayer()
    {
        if (!_playerFollowingComponent)
        {
            Debug.LogError("Missing components");
            return;
        }
        
        _playerFollowingComponent.TryFollowPlayer();
        _playerFollowingComponent.NotifyMoving();
    }
    
    private void StopFollow()
    {
        if (!_playerFollowingComponent)
        {
            Debug.LogError("Missing components");
            return;
        }
        
        _playerFollowingComponent.NotifyPlayerReached();
        _playerFollowingComponent.NotifyStoppedMoving();
    }

    #endregion

    #region Fields Set

    public void OnGameStateChanged(GameState newState)
    {
        IsActive = GameStateCaster.CastGameStateToActivityState(newState);
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _playerFollowingComponent);
    }

    #endregion
}
