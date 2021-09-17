using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Component : MonoBehaviour
{
    public event EventHandler<ProductParamsEventArgs> OnProductPurchased;
    
    public List<ProductParams> AvailableProducts { get; private set; }

    private PlayerWallet_Component _playerWalletComponent;
    
    public void TryPurchaseProduct(ProductParams orderedProduct)
    {
        if (AvailableProducts == null || !_playerWalletComponent || !orderedProduct)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (!AvailableProducts.Contains(orderedProduct))
        {
            Debug.LogWarning("Ordered product unavailable");
            return;
        }

        if (!_playerWalletComponent.TryChangeWalletBalance(-orderedProduct.Price)) return;
        
        AvailableProducts.Remove(orderedProduct);
        NotifyProductPurchased(orderedProduct);
    }

    #region Auxiliary

    private void NotifyProductPurchased(ProductParams productParams)
    {
        Debug.Log("Purchase commited");
        var args = new ProductParamsEventArgs
        {
            ProductParams = productParams
        };
        OnProductPurchased?.Invoke(this, args);
    }

    #endregion
    
    #region Fields Setting

    public void TryAddAvailableProducts(params ProductParams[] productsToAdd)
    {
        if (AvailableProducts == null || productsToAdd == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedProduct in productsToAdd)
        {
            if (!selectedProduct)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            AvailableProducts.Add(selectedProduct);
        }
    }

    public void TryRemoveAvailableProduct(params ProductParams[] productsToRemove)
    {
        if (AvailableProducts == null || productsToRemove == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedProductToRemove in productsToRemove)
        {
            if (!AvailableProducts.Contains(selectedProductToRemove)) continue;

            AvailableProducts.Remove(selectedProductToRemove);
        }
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        if (AvailableProducts == null)
        {
            AvailableProducts = new List<ProductParams>();
        }

        _playerWalletComponent = FindObjectOfType<PlayerWallet_Component>();
    }

    #endregion
}
