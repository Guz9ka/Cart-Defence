using System;
using UnityEngine;

public class ShopChoice_Data : MonoBehaviour
{
    public event EventHandler<ProductParamsEventArgs> OnNewShopChoiceMade;
    
    public ProductParams CurrentShopChoice { get; private set; }

    public void TrySetCurrentShopChoice(ProductParams newShopChoice)
    {
        if (!newShopChoice)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        CurrentShopChoice = newShopChoice;
        NotifyNewShopChoiceMade(CurrentShopChoice);
    }

    #region Auxiliary

    private void NotifyNewShopChoiceMade(ProductParams newShopChoice)
    {
        var args = new ProductParamsEventArgs
        {
            ProductParams = newShopChoice
        };
        OnNewShopChoiceMade?.Invoke(this, args);
    }

    #endregion
}
