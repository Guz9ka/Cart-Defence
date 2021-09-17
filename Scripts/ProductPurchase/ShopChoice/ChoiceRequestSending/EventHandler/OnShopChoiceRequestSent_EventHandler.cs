using UnityEngine;

public class OnShopChoiceRequestSent_EventHandler : MonoBehaviour
{
    private ShopChoice_Data _shopChoiceData;
    
    private void HandleEvent(object s, ProductParamsEventArgs args)
    {
        if (!_shopChoiceData)
        {
            Debug.LogWarning("Missing components");
        }

        if (_shopChoiceData)
        {
            _shopChoiceData.TrySetCurrentShopChoice(args.ProductParams);
        }
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        ProductChoiceRequestSender_Component.OnShopChoiceRequestSent -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        ProductChoiceRequestSender_Component.OnShopChoiceRequestSent += HandleEvent;
        TryGetComponent(out _shopChoiceData);
    }

    #endregion
}
