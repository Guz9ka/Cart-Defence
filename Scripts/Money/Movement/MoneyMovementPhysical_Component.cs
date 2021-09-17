using System;
using System.Collections;
using UnityEngine;

public class MoneyMovementPhysical_Component : MonoBehaviour
{
    //TODO optimize with a pool
    public static event EventHandler<MoneyMovementComponentEventArgs> OnDestinationReached;
    
    [SerializeField] private MoneyMovementParams movementParams;
    
    private bool _isMovingToDestination;
    
    private Rigidbody _rigidbody;

    public void TryLaunchMoney(Vector3 direction)
    {
        if (!_rigidbody || !movementParams)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _rigidbody.AddForce(direction * movementParams.DropForce);
        StartCoroutine(TryStartDestinationMovement());
    }

    private void Update()
    {
        if (!_isMovingToDestination) return;
        
        var destinationWorldPosition = TryGetDestinationWorldPosition();
        var distanceToDestination = GetDistanceToDestination(destinationWorldPosition);

        if (distanceToDestination > movementParams.StopDistance)
        {
            TrySmoothlyRotateOnDestination(destinationWorldPosition);
            TryMoveToDestination();
        }
        else
        {
            NotifyDestinationReached();
        }
    }

    #region Available Actions

    private void TryMoveToDestination()
    {
        if (!movementParams)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        transform.position += transform.forward * (movementParams.MoveSpeed * Time.deltaTime);
    }

    private void TrySmoothlyRotateOnDestination(Vector3 destinationPoint)
    {
        if (!MoneyDestinationPoint_Indicator.Instance || !movementParams)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var desiredRotation = Quaternion.LookRotation(destinationPoint - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 
            movementParams.RotationSpeed * Time.deltaTime);
    }

    private void NotifyDestinationReached()
    {
        var args = new MoneyMovementComponentEventArgs
        {
            MoneyMovementComponent = this
        };
        OnDestinationReached?.Invoke(this, args);
    }

    #endregion

    #region Auxiliary

    private IEnumerator TryStartDestinationMovement()
    {
        if (!movementParams || !_rigidbody)
        {
            Debug.LogWarning("Missing components");
            yield break;
        }
        
        yield return new WaitForSeconds(movementParams.TimeBeforeMovementToDestination);

        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        _isMovingToDestination = true;
    }

    private Vector3 TryGetDestinationWorldPosition()
    {
        if (!movementParams || !MoneyDestinationPoint_Indicator.Instance)
        {
            Debug.LogWarning("Missing components");
            return Vector3.zero;
        }
        
        var destinationPositionWorld = Globals.MainCamera.ScreenToWorldPoint
            (MoneyDestinationPoint_Indicator.Instance.transform.position);
        destinationPositionWorld += movementParams.DestinationOffset;

        return destinationPositionWorld;
    }

    private float GetDistanceToDestination(Vector3 destinationWorldPosition)
    {
        return VectorHelper.GetVectorsDistance(transform.position, destinationWorldPosition);
    }
    
    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _rigidbody);
    }

    #endregion
}
