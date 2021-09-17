using System;
using UnityEngine;

public class ProductChoiceRequestSender_Component : MonoBehaviour
{
    public static event EventHandler<ProductParamsEventArgs> OnShopChoiceRequestSent;
    
    private Product_Data _productData;

    public void TrySendShopChoiceRequest()
    {
        if (!_productData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        var args = new ProductParamsEventArgs
        {
            ProductParams = _productData.ProductParams
        };
        OnShopChoiceRequestSent?.Invoke(this, args);
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _productData);
    }

    #endregion
}
