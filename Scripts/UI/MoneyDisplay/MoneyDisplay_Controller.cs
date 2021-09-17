using UnityEngine;

public class MoneyDisplay_Controller : MonoBehaviour
{
    private PlayerWallet_Component _playerWalletComponent;
    private MoneyDisplay_Component _moneyDisplayComponent;

    private void TrySetActualValue()
    {
        if (!_playerWalletComponent || !_moneyDisplayComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _moneyDisplayComponent.TryDisplayNewValue(_playerWalletComponent.CurrentBalance);
    }

    #region State Change Reactions

    private void OnEnable()
    {
        TrySetActualValue();
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        _playerWalletComponent = FindObjectOfType<PlayerWallet_Component>();
        TryGetComponent(out _moneyDisplayComponent);
    }

    #endregion
}
