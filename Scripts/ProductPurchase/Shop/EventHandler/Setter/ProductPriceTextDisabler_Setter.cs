using UnityEngine;

public class ProductPriceTextDisabler_Setter : MonoBehaviour
{
    private void Awake()
    {
        if (!TryGetComponent(out OnProductPurchased_EventHandler productPurchasedEventHandler))
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var shopProductPriceDisplayer = FindObjectOfType<ShopProductPriceDisplayer_Component>();
        if (!shopProductPriceDisplayer) return;

        shopProductPriceDisplayer.TryGetComponent(out GameObjectsStateChanger_Component productPriceTextDisabler);
        productPurchasedEventHandler.TrySetProductPriceTextDisabler(productPriceTextDisabler);
    }
}
