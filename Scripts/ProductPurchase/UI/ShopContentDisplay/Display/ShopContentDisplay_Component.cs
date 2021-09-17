using System.Collections.Generic;
using UnityEngine;

// This script spawns product cards to display them in the UI.
public class ShopContentDisplay_Component : MonoBehaviour
{
    [field:SerializeField] public ProductType DisplayedProductsType { get; private set; }
    
    [SerializeField] private Transform shopContentTransform;
    [SerializeField] private Product_Data productCardTemplate;

    private List<Product_Data> _spawnedProductCards;
    
    public void TryDisplayProductCard(ProductParams productParamsToDisplay)
    {
        if (!shopContentTransform || !productCardTemplate|| !productParamsToDisplay || _spawnedProductCards == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (productParamsToDisplay.ProductType != DisplayedProductsType) return;

        productCardTemplate.SetProductParams(productParamsToDisplay);
        
        var spawnedProductCard =
            ObjectSpawner.TrySpawnObject<Product_Data>(productCardTemplate, Vector3.zero, Quaternion.identity);
        if (!spawnedProductCard) return;

        spawnedProductCard.transform.SetParent(shopContentTransform);
        _spawnedProductCards.Add(spawnedProductCard);
    }

    public void TryDestroyAllProductCards()
    {
        if (_spawnedProductCards == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedProductCard in _spawnedProductCards)
        {
            TryDestroyProductCard(selectedProductCard);
        }

        _spawnedProductCards = new List<Product_Data>();
    }

    public Product_Data TryGetSpawnedProduct(ProductParams desiredProductParams)
    {
        if (_spawnedProductCards == null || _spawnedProductCards.Count == 0)
        {
            Debug.LogWarning("Missing components");
            return null;
        }

        foreach (var selectedProductCard in _spawnedProductCards)
        {
            if (!selectedProductCard)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            if (selectedProductCard.ProductParams != desiredProductParams) continue;

            return selectedProductCard;
        }

        return null;
    }

    #region Auxiliary
    
    private void TryDestroyProductCard(Product_Data productCardToDestroy)
    {
        if (!productCardToDestroy || _spawnedProductCards == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        productCardToDestroy.transform.SetParent(null);
        ObjectDestroyer.TryDestroyObject(productCardToDestroy.gameObject);
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        _spawnedProductCards = new List<Product_Data>();
    }

    #endregion
}
