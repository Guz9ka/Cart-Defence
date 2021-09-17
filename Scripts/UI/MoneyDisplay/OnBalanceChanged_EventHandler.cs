using UnityEngine;

public class OnBalanceChanged_EventHandler : MonoBehaviour
{
    private MoneyDisplay_Component _moneyDisplayComponent;
    
    private PlayerWallet_Component _playerWalletComponent;

    private void HandleEvent(object s, IntEventArgs args)
    {
        if (!_moneyDisplayComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _moneyDisplayComponent.TryDisplayNewValue(args.Value);
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_playerWalletComponent)
        {
            _playerWalletComponent.OnBalanceChanged -= HandleEvent;
        }
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _moneyDisplayComponent);
        
        _playerWalletComponent = FindObjectOfType<PlayerWallet_Component>();
        if (_playerWalletComponent)
        {
            _playerWalletComponent.OnBalanceChanged += HandleEvent;
        }
    }

    #endregion
}
