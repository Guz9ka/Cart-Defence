using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator_Component : MonoBehaviour
{
    [SerializeField] private Image healthIndicator;

    public void TryIndicateCurrentHealth(int currentHealth, int maxHealth)
    {
        if (!healthIndicator)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var currentFillAmount = (float)currentHealth / maxHealth;
        healthIndicator.fillAmount = currentFillAmount;
    }
    
    public void TryChangeState(bool newState)
    {
        if (!healthIndicator)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        healthIndicator.gameObject.SetActive(newState);
    }

    #region Initialization

    private void Awake()
    {
        TryChangeState(false);
    }

    #endregion
}
