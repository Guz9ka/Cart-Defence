using UnityEngine;

public class PlayerMaxHealth_Setter : MaxHealth_Setter
{
    private Player_Data _playerData;
    
    protected override int TryGetMaxHealth()
    {
        if (!_playerData || !_playerData.PlayerParams)
        {
            Debug.LogWarning("Missing components");
            return base.TryGetMaxHealth();
        }

        return _playerData.PlayerParams.MaxHealth;
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _playerData);
    }

    #endregion
}
