using System;
using UnityEngine;

public class DefaultProductsToPlayerOwnedProducts_Setter : MonoBehaviour
{
    private DefaultSelectedProducts_Data _defaultSelectedProductsData;
    private PlayerOwnedProducts_Data _playerOwnedProductsData;

    private void TrySetAvailableProducts()
    {
        if (!_defaultSelectedProductsData || !_defaultSelectedProductsData.DefaultSelectionParams || 
            _defaultSelectedProductsData.DefaultSelectionParams.DefaultSelectedProducts == null|| !_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var productToAdd in _defaultSelectedProductsData.DefaultSelectionParams.DefaultSelectedProducts)
        {
            if (!productToAdd)
            {
                Debug.LogWarning("Missing components");
                return;
            }
            
            _playerOwnedProductsData.TryAddNewProduct(productToAdd);
        }
    }

    #region Initialization

    private void Awake()
    {
        _defaultSelectedProductsData = FindObjectOfType<DefaultSelectedProducts_Data>();
        TryGetComponent(out _playerOwnedProductsData);
        TrySetAvailableProducts();
    }

    #endregion
}
