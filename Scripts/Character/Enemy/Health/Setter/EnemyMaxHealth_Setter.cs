using UnityEngine;

public class EnemyMaxHealth_Setter : MaxHealth_Setter
{
    private Enemy_Data _enemyData;
    
    protected override int TryGetMaxHealth()
    {
        if (!_enemyData || !_enemyData.EnemyParams)
        {
            Debug.LogWarning("Missing components");
            return base.TryGetMaxHealth();
        }

        return _enemyData.EnemyParams.MaxHealth;
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _enemyData);
    }

    #endregion
}
