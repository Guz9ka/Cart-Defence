using UnityEngine;

public class ProductInteractionButtonsStateSwitcher_Component : MonoBehaviour
{
    [SerializeField] private GameObjectsStateChanger_Component purchaseUIElements;
    [SerializeField] private GameObjectsStateChanger_Component selectionUIElements;

    private ShopChoice_Data _shopChoiceData;
    
    private PlayerOwnedProducts_Data _playerOwnedProductsData;
    
    public void TryChangeButtonsState()
    {
        if (!purchaseUIElements || !selectionUIElements || !_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var currentShopChoice = TryGetCurrentShopChoice();
        var productAlreadyOwned = _playerOwnedProductsData.TryCheckIfProductOwned(currentShopChoice);

        if (productAlreadyOwned)
        {
            TryEnableSelectionElements();
        }
        else
        {
            TryEnablePurchaseElements();
        }
    }

    #region Avaialbe Actions

    private ProductParams TryGetCurrentShopChoice()
    {
        if (!_shopChoiceData)
        {
            Debug.LogWarning("Missing components");
            return null;
        }

        return _shopChoiceData.CurrentShopChoice;
    }
    
    private void TryEnablePurchaseElements()
    {
        if (!purchaseUIElements || !selectionUIElements)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        selectionUIElements.ChangeGameObjectsStates(false);
        purchaseUIElements.ChangeGameObjectsStates(true);
    }

    private void TryEnableSelectionElements()
    {
        if (!purchaseUIElements || !selectionUIElements)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        purchaseUIElements.ChangeGameObjectsStates(false);
        selectionUIElements.ChangeGameObjectsStates(true);
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        _shopChoiceData = FindObjectOfType<ShopChoice_Data>();
        _playerOwnedProductsData = FindObjectOfType<PlayerOwnedProducts_Data>();
    }

    #endregion
}
