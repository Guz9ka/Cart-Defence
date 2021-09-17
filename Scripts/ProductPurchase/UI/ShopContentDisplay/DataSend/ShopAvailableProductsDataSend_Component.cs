using UnityEngine;

public class ShopAvailableProductsDataSend_Component : ProductDataSender_Component
{
    private Shop_Component _shopComponent;
    
    protected override void TrySetSentProducts()
    {
        if (!_shopComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        SentProducts = _shopComponent.AvailableProducts;
    }

    #region Initialization

    protected override void Awake()
    {
        _shopComponent = FindObjectOfType<Shop_Component>();
        base.Awake();
    }

    #endregion
}
