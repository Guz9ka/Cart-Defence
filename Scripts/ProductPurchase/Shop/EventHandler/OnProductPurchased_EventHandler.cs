using UnityEngine;

public class OnProductPurchased_EventHandler : MonoBehaviour
{
    private ProductDataSender_Component[] _productDataSenders;
    private PlayerOwnedProducts_Data _playerOwnedProductsData;
    private ShopContentDisplay_Component _shopContentDisplayComponent;
    private GameObjectsStateChanger_Component _productPriceTextStateChanger;
    private ProductInteractionButtonsStateSwitcher_Component _interactionButtonsStateSwitcher;
    
    private Shop_Component _shopComponent;
    
    private void HandleEvent(object s, ProductParamsEventArgs args)
    {
        TryRemovePurchasedProductFromShop(args);
        TryAddPurchasedProductToPlayer(args);
        TrySendRequestDestroyInitializedProducts();
        TrySendRequestInitializeNewProducts();
        TrySendRequestDisablePriceDisplay();
        TrySendButtonStateSwitchRequest();
    }

    #region Available Actions

    private void TrySendButtonStateSwitchRequest()
    {
        if (!_interactionButtonsStateSwitcher)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _interactionButtonsStateSwitcher.TryChangeButtonsState();
    }
    
    private void TryRemovePurchasedProductFromShop(ProductParamsEventArgs args)
    {
        if (!_shopComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _shopComponent.TryRemoveAvailableProduct(args.ProductParams);
    }

    private void TryAddPurchasedProductToPlayer(ProductParamsEventArgs args)
    {
        if (!_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _playerOwnedProductsData.TryAddNewProduct(args.ProductParams);
    }

    private void TrySendRequestInitializeNewProducts()
    {
        if (_productDataSenders == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedDataSender in _productDataSenders)
        {
            if (!selectedDataSender)
            {
                Debug.LogWarning("Missing components");
                continue;
            }

            selectedDataSender.TrySendProductsData();
        }
    }

    private void TrySendRequestDestroyInitializedProducts()
    {
        if (!_shopContentDisplayComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _shopContentDisplayComponent.TryDestroyAllProductCards();
    }
    
    private void TrySendRequestDisablePriceDisplay()
    {
        if (!_productPriceTextStateChanger)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _productPriceTextStateChanger.ChangeGameObjectsStates(false);
    }

    #endregion

    #region State Change Reactions

    private void OnDisable()
    {
        if (_shopComponent)
        {
            _shopComponent.OnProductPurchased -= HandleEvent;
        }
    }

    #endregion

    #region Fields Setting

    public void TrySetProductPriceTextDisabler(GameObjectsStateChanger_Component newProductPriceTextDisabler)
    {
        if (!newProductPriceTextDisabler)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _productPriceTextStateChanger = newProductPriceTextDisabler;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _shopComponent))
        {
            _shopComponent.OnProductPurchased += HandleEvent;
        }
        
        _playerOwnedProductsData = FindObjectOfType<PlayerOwnedProducts_Data>();
        _productDataSenders = FindObjectsOfType<ProductDataSender_Component>();
        _shopContentDisplayComponent = FindObjectOfType<ShopContentDisplay_Component>();
        _interactionButtonsStateSwitcher = FindObjectOfType<ProductInteractionButtonsStateSwitcher_Component>();
    }

    #endregion
}
