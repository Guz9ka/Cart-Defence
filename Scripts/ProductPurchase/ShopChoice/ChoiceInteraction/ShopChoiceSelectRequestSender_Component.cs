using UnityEngine;

public class ShopChoiceSelectRequestSender_Component : ShopChoiceInteractionRequestSender_Component
{
    private PlayerSelectedProducts_Data _playerSelectedProductsData;
    
    public override void SendRequest()
    {
        if (!_playerSelectedProductsData || !ShopChoiceData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _playerSelectedProductsData.TrySelectNewProduct(ShopChoiceData.CurrentShopChoice);
    }

    #region Initialiation

    protected override void Awake()
    {
        base.Awake();

        _playerSelectedProductsData = FindObjectOfType<PlayerSelectedProducts_Data>();
    }

    #endregion
}
