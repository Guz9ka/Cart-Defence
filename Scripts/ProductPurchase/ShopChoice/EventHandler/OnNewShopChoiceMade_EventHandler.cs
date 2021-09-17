using UnityEngine;

public class OnNewShopChoiceMade_EventHandler : MonoBehaviour
{
    private ShopProductPriceDisplayer_Component _shopProductPriceDisplayerComponent;
    private ProductVisualDisplay_Component _productVisualDisplayComponent;
    private ProductInteractionButtonsStateSwitcher_Component _buttonsInteractionButtonsStateSwitcher;
    
    private ShopChoice_Data _shopChoiceData;
    
    private void HandleEvent(object s, ProductParamsEventArgs args)
    {
        TrySendButtonsStateSwitchRequest();
        TryDisplayProductVisual(args.ProductParams);
        TrySendRequestDisplayProductPrice(args.ProductParams);
    }

    #region Available Actions

    private void TrySendButtonsStateSwitchRequest()
    {
        if (!_buttonsInteractionButtonsStateSwitcher)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _buttonsInteractionButtonsStateSwitcher.TryChangeButtonsState();
    }
    
    private void TryDisplayProductVisual(ProductParams productParams)
    {
        if (!_productVisualDisplayComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _productVisualDisplayComponent.TryDisplay(productParams);
    }
    
    private void TrySendRequestDisplayProductPrice(ProductParams productParams)
    {
        if (!_shopProductPriceDisplayerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _shopProductPriceDisplayerComponent.TryDisplay(productParams);
    }
    
    #endregion

    #region State Change Reactions

    private void OnDestroy()
    {
        if (_shopChoiceData)
        {
            _shopChoiceData.OnNewShopChoiceMade -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _shopChoiceData))
        {
            _shopChoiceData.OnNewShopChoiceMade += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
        }

        _buttonsInteractionButtonsStateSwitcher = FindObjectOfType<ProductInteractionButtonsStateSwitcher_Component>();
        _productVisualDisplayComponent = FindObjectOfType<ProductVisualDisplay_Component>();
        _shopProductPriceDisplayerComponent = FindObjectOfType<ShopProductPriceDisplayer_Component>();
    }

    #endregion
}
