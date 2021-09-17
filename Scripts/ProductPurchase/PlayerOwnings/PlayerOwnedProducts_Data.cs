using System.Collections.Generic;
using UnityEngine;

public class PlayerOwnedProducts_Data : MonoBehaviour
{
    [field:SerializeField] public List<ProductParams> OwnedProducts { get; private set; }

    public void TryAddNewProduct(ProductParams newProduct)
    {
        if (!newProduct)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        OwnedProducts.Add(newProduct);
    }

    public bool TryCheckIfProductOwned(ProductParams productToCheck)
    {
        if (OwnedProducts == null)
        {
            Debug.LogWarning("Missing components");
            return false;
        }

        return OwnedProducts.Contains(productToCheck);
    }
    
    #region Initialization

    private void Awake()
    {
        if (OwnedProducts == null)
        {
            OwnedProducts = new List<ProductParams>();
        }
    }

    #endregion
}
