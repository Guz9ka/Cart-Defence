using UnityEngine;

public class OnShopScreenStateChanged_EventHandler : MonoBehaviour
{
    private PlayerSelectedProductsShopDisplay_Component _selectedProductsShopDisplay;
    private ShopContentInitializationRequestSender_Component _contentInitializationRequestSender;
    private ShopContentDisplay_Component _shopContentDisplayComponent;
    
    private GameObjectsStateChanger_Component _gameObjectsStateChangerComponent;
    
    private void HandleEvent(object s, BoolEventArgs args)
    {
        // If enabled
        TrySendContentInitializationRequest(args);
        TrySendRequestPlayerSelectedProductSet(args);
        
        // If disabled
        TrySendContentDestroyRequest(args);
    }

    #region Available Actions

    private void TrySendRequestPlayerSelectedProductSet(BoolEventArgs args)
    {
        if (!_selectedProductsShopDisplay)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        if (args.BoolValue != true) return;
        
        _selectedProductsShopDisplay.TrySetSelectedProductIfSelectionIsNull();
    }
    
    private void TrySendContentInitializationRequest(BoolEventArgs args)
    {
        if (!args.BoolValue) return;
        if (!_contentInitializationRequestSender)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _contentInitializationRequestSender.TrySendContentDisplayRequest();
    }
    
    private void TrySendContentDestroyRequest(BoolEventArgs args)
    {
        if (args.BoolValue) return;
        if (!_shopContentDisplayComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _shopContentDisplayComponent.TryDestroyAllProductCards();
    }

    #endregion

    #region State Change Reactions

    private void OnDisable()
    {
        if (_gameObjectsStateChangerComponent)
        {
            _gameObjectsStateChangerComponent.OnStateChanged -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _gameObjectsStateChangerComponent))
        {
            _gameObjectsStateChangerComponent.OnStateChanged += HandleEvent;
        }

        _contentInitializationRequestSender = FindObjectOfType<ShopContentInitializationRequestSender_Component>();
        _shopContentDisplayComponent = FindObjectOfType<ShopContentDisplay_Component>();
        _selectedProductsShopDisplay = FindObjectOfType<PlayerSelectedProductsShopDisplay_Component>();
    }

    #endregion
}
