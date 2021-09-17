using UnityEngine;

public class ShopContentInitialization_Setter : MonoBehaviour
{
    private Shop_Data _shopData;
    private Shop_Component _shopComponent;
    private PlayerOwnedProducts_Data _playerOwnedProductsData;

    private void TrySetShopContent()
    {
        if (!_shopData || !_shopData.ShopParams || !_shopComponent || !_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedProduct in _shopData.ShopParams.AvailableProducts)
        {
            var productAlreadyOwned = _playerOwnedProductsData.TryCheckIfProductOwned(selectedProduct);
            if (productAlreadyOwned) continue;
            
            _shopComponent.TryAddAvailableProducts(selectedProduct);
        }
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _shopData);
        TryGetComponent(out _shopComponent);
        _playerOwnedProductsData = FindObjectOfType<PlayerOwnedProducts_Data>();
        
        TrySetShopContent();
    }

    #endregion
}
