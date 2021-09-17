using UnityEngine;

public class OnMoneyDestinationReached_EventHandler : MonoBehaviour
{
    private PlayerWallet_Component _playerWalletComponent;

    private void HandleEvent(object s, MoneyMovementComponentEventArgs args)
    {
        TryChangePlayerBalance();
        TryDestroyMoneyMovementGameObject(args.MoneyMovementComponent);
    }

    #region Available Actions

    private void TryChangePlayerBalance()
    {
        if (!_playerWalletComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _playerWalletComponent.TryChangeWalletBalance(Globals.MoneyAmountInOneStack);
    }

    private void TryDestroyMoneyMovementGameObject(MoneyMovementPhysical_Component moneyMovementPhysicalComponent)
    {
        if (!moneyMovementPhysicalComponent || !moneyMovementPhysicalComponent.gameObject)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        ObjectDestroyer.TryDestroyObject(moneyMovementPhysicalComponent.gameObject);
    }

    #endregion

    #region State Change Reactions

    private void OnDisable()
    {
        MoneyMovementPhysical_Component.OnDestinationReached -= HandleEvent;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        MoneyMovementPhysical_Component.OnDestinationReached += HandleEvent;

        _playerWalletComponent = FindObjectOfType<PlayerWallet_Component>();
    }

    #endregion
}