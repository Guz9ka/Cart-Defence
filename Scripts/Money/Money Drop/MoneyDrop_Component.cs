using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoneyDrop_Component : MonoBehaviour
{
    public event EventHandler<MoneyMovementComponentEventArgs> OnMoneySpawned;
    
    [SerializeField] private MoneyDropParams moneyDropParams;
    
    public void TryDropMoney()
    {
        TryDropMoney(moneyDropParams);
    }
    
    public void TryDropMoney(MoneyDropParams dropParams)
    {
        if (!dropParams)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        for (int i = 0; i < GetRandomDropAmount(dropParams); i++)
        {
            TrySpawnAndLaunchMoney(dropParams);
        }
    }

    #region Available Actions

    protected virtual void TrySpawnAndLaunchMoney(MoneyDropParams dropParams)
    {
        if (!dropParams)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        // Spawn Money
        var spawnedMoney = ObjectSpawner.TrySpawnObject(dropParams.MoneyPrefab, transform.position, 
            dropParams.MoneyPrefab.transform.rotation);
        if (!spawnedMoney) return;

        // Initialize and activate drop and movement to the destination
        if (!spawnedMoney.TryGetComponent(out MoneyMovementPhysical_Component moneyMovementComponent)) return;
        TryActivateMoneyDrop(dropParams, moneyMovementComponent);
        
        // Notify money spawned
        NotifyMoneySpawned(moneyMovementComponent);
    }

    #endregion

    #region Auxiliary

    private void TryActivateMoneyDrop(MoneyDropParams dropParams, MoneyMovementPhysical_Component component)
    {
        if (!dropParams || !component)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        var launchDirection = RandomValueBetweenVectors.GetRandomVectorInRange(dropParams.DropDirectionsRange.Min,
            dropParams.DropDirectionsRange.Max);
        component.TryLaunchMoney(launchDirection);
    }

    private void NotifyMoneySpawned(MoneyMovementPhysical_Component moneyMovementComponent)
    {
        var args = new MoneyMovementComponentEventArgs
        {
            MoneyMovementComponent = moneyMovementComponent
        };
        OnMoneySpawned?.Invoke(this, args);
    }
    
    private int GetRandomDropAmount(MoneyDropParams dropParams) => 
        Random.Range(dropParams.DropAmount.Min, dropParams.DropAmount.Max);
    
    #endregion
}
