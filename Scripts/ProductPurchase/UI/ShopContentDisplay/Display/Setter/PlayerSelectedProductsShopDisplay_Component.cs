using UnityEngine;

public class PlayerSelectedProductsShopDisplay_Component : MonoBehaviour
{
    private ShopContentDisplay_Component _shopContentDisplayComponent;
    private PlayerSelectedProducts_Data _playerSelectedProductsData;
    private ShopChoice_Data _shopChoiceData;

    public void TrySetSelectedProductIfSelectionIsNull()
    {
        if (!_shopContentDisplayComponent || !_playerSelectedProductsData || !_shopChoiceData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        if (_shopChoiceData.CurrentShopChoice) return;

        TryTriggerNewShopChoiceSent();
    }

    #region Available Actions

    private void TryTriggerNewShopChoiceSent()
    {
        var displayedProductType = _shopContentDisplayComponent.DisplayedProductsType;
        var productToDisplay = _playerSelectedProductsData.TryGetSelectedProductOfType(displayedProductType);

        var spawnedProductCard = _shopContentDisplayComponent.TryGetSpawnedProduct(productToDisplay);
        if (!spawnedProductCard)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        spawnedProductCard.TryGetComponent(out ProductChoiceRequestSender_Component choiceRequestSenderComponent);
        if (!choiceRequestSenderComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        choiceRequestSenderComponent.TrySendShopChoiceRequest();
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _shopContentDisplayComponent);
        
        _shopChoiceData = FindObjectOfType<ShopChoice_Data>();
        _playerSelectedProductsData = FindObjectOfType<PlayerSelectedProducts_Data>();
    }

    #endregion
}
