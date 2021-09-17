using UnityEngine;

public class ShopChoicePurchaseRequestSender_Component : ShopChoiceInteractionRequestSender_Component
{
    private Shop_Component _shopComponent;
    
    public override void SendRequest()
    {
        if (!_shopComponent || !ShopChoiceData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _shopComponent.TryPurchaseProduct(ShopChoiceData.CurrentShopChoice);
    }

    #region Initialization

    protected override void Awake()
    {
        base.Awake();

        _shopComponent = FindObjectOfType<Shop_Component>();
    }

    #endregion
}
