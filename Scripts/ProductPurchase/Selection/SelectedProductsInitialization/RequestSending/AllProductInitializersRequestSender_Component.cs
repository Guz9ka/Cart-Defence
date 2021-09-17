using System.Collections.Generic;
using UnityEngine;

public class AllProductInitializersRequestSender_Component : MonoBehaviour
{
    private List<ProductInitializer_Component> _productInitializers;

    public void TrySendInitializationRequests(ProductParams newProductToInitialize)
    {
        if (_productInitializers == null || _productInitializers.Count <= 0 || !newProductToInitialize)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedProductInitializer in _productInitializers)
        {
            if (!selectedProductInitializer)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            selectedProductInitializer.TryInitializeNewProduct(newProductToInitialize);
        }
    }

    #region Auxiliary

    public void TrySendInitializationRequests(ProductParams[] productsParameters)
    {
        if (productsParameters == null || productsParameters.Length <= 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedProduct in productsParameters)
        {
            TrySendInitializationRequests(selectedProduct);
        }
    }

    #endregion

    #region Fields Setting

    public void TryAddProductInitializer(ProductInitializer_Component productInitializerToAdd)
    {
        if (!productInitializerToAdd || _productInitializers == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _productInitializers.Add(productInitializerToAdd);
    }

    #endregion

    #region Initialization
    
    private void Awake()
    {
        _productInitializers = new List<ProductInitializer_Component>();
    }

    #endregion
}
