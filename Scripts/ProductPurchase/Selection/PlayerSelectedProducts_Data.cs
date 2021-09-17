using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectedProducts_Data : MonoBehaviour
{
    public event EventHandler<ProductParamsEventArgs> OnNewProductSelected;
    public event EventHandler<ProductParamsEventArgs> OnProductDeselected;
    
    public List<ProductParams> SelectedProducts { get; private set; }

    private PlayerOwnedProducts_Data _playerOwnedProductsData;
    
    public void TrySelectNewProduct(ProductParams newProductToSelect)
    {
        if (!newProductToSelect || SelectedProducts == null || !_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        if (!_playerOwnedProductsData.TryCheckIfProductOwned(newProductToSelect))
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        if (TryCheckIfProductAlreadySelected(newProductToSelect)) return;
        
        TryRemoveAlreadySelectedProduct(newProductToSelect.ProductType);
        TrySelectProduct(newProductToSelect);
    }

    public ProductParams TryGetSelectedProductOfType(ProductType desiredProductType)
    {
        if (SelectedProducts == null || SelectedProducts.Count == 0)
        {
            Debug.LogWarning("Missing components");
            return null;
        }

        foreach (var selectedProduct in SelectedProducts)
        {
            if (!selectedProduct)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            if (selectedProduct.ProductType != desiredProductType) continue;

            return selectedProduct;
        }

        return null;
    }
    
    #region Available Actions

    private bool TryCheckIfProductAlreadySelected(ProductParams productToCheck)
    {
        if (!productToCheck || SelectedProducts == null)
        {
            Debug.LogWarning("Missing components");
            return false;
        }

        return SelectedProducts.Contains(productToCheck);
    }
    
    private void TrySelectProduct(ProductParams newProduct)
    {
        if (!newProduct)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        SelectedProducts.Add(newProduct);
        NotifyNewProductSelected(newProduct);
    }
    
    private void TryRemoveAlreadySelectedProduct(ProductType productTypeToRemove)
    {
        var foundProductToRemove = TryFindProductToRemove(productTypeToRemove);
        if (!foundProductToRemove)
        {
            return;
        }
        
        SelectedProducts.Remove(foundProductToRemove);
        NotifyProductDeselected(foundProductToRemove);
    }

    private ProductParams TryFindProductToRemove(ProductType productTypeToRemove)
    {
        if (SelectedProducts == null)
        {
            Debug.LogWarning("Missing components");
            return null;
        }

        foreach (var selectedProduct in SelectedProducts)
        {
            if (!selectedProduct)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            if (selectedProduct.ProductType != productTypeToRemove) continue;

            var foundProductToRemove = selectedProduct;
            return foundProductToRemove;
        }

        return null;
    }

    #endregion

    #region Auxiliary

    private void NotifyNewProductSelected(ProductParams newProduct)
    {
        var args = new ProductParamsEventArgs
        {
            ProductParams = newProduct
        };
        OnNewProductSelected?.Invoke(this, args);
    }
    
    private void NotifyProductDeselected(ProductParams deselectedProduct)
    {
        var args = new ProductParamsEventArgs
        {
            ProductParams = deselectedProduct
        };
        OnProductDeselected?.Invoke(this, args);
    }
    
    #endregion

    #region Initialization

    private void Awake()
    {
        if (SelectedProducts == null)
        {
            SelectedProducts = new List<ProductParams>();
        }

        _playerOwnedProductsData = FindObjectOfType<PlayerOwnedProducts_Data>();
    }

    #endregion
}
