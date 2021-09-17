using System;
using UnityEngine;

public class ClosestEnemyIndicatorHighlight_Controller : MonoBehaviour
{
    private HealthIndicator_Component _lastEnemyHealthIndicator;
    private Health_Component _lastEnemyHealthComponent;
    private Enemy_Data _lastNearestEnemy;
    
    private NearbyEnemies_Data _nearbyEnemiesData;

    private void Update()
    {
        if (!_nearbyEnemiesData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        // Найти ближайшего врага, если его нет.
        if (_nearbyEnemiesData.NearestEnemy && !_lastNearestEnemy)
        {
            TrySetNewLastEnemy();
        }

        if (_nearbyEnemiesData.NearestEnemy == _lastNearestEnemy)
        {
            // Если выделенный враг является ближайшим, то активировать индикатор.
            TryChangeLastEnemyIndicatorState(true);
        }
        else
        {
            // Если ближайший враг изменился, то отключить индикатор.
            TryChangeLastEnemyIndicatorState(false);
            
            // Если он изменился на другого врага, а не на нулл,
            // то попытаться установить нового ближайшего врага.
            if (_nearbyEnemiesData.EnemiesCount > 0)
            {
                TrySetNewLastEnemy();
            }
        }
    }

    #region Available Actions

    private void TrySetNewLastEnemy()
    {
        if (!_nearbyEnemiesData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        TryUnsubscribeHealthEvent();

        _lastNearestEnemy = _nearbyEnemiesData.NearestEnemy;
        if (!_lastNearestEnemy || !_lastNearestEnemy.gameObject.activeInHierarchy) return;
        
        _lastNearestEnemy.TryGetComponent(out _lastEnemyHealthIndicator);
        _lastNearestEnemy.TryGetComponent(out _lastEnemyHealthComponent);
        
        TrySubscribeHealthEvent();
    }
    
    private void TryUpdateHealthIndicator(object s, EventArgs args)
    {
        if (!_lastEnemyHealthIndicator || !_lastEnemyHealthComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var currentHealth = _lastEnemyHealthComponent.CurrentHealth;
        var maxHealth = _lastEnemyHealthComponent.MAXHealth;
        
        _lastEnemyHealthIndicator.TryIndicateCurrentHealth(currentHealth, maxHealth);
    }

    #endregion

    #region Auxiliary

    private void TryChangeLastEnemyIndicatorState(bool newState)
    {
        if (!_lastEnemyHealthIndicator)
        {
            return;
        }
            
        _lastEnemyHealthIndicator.TryChangeState(newState);
    }
    
    private void TrySubscribeHealthEvent()
    {
        if (!_lastEnemyHealthComponent) return;

        _lastEnemyHealthComponent.OnDamageApplied += TryUpdateHealthIndicator;
    }
    
    private void TryUnsubscribeHealthEvent()
    {
        if (!_lastEnemyHealthComponent) return;

        _lastEnemyHealthComponent.OnDamageApplied -= TryUpdateHealthIndicator;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        _nearbyEnemiesData = FindObjectOfType<NearbyEnemies_Data>();
    }

    #endregion
}
