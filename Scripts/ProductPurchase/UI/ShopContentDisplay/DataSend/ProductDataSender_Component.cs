using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProductDataSender_Component : MonoBehaviour
{
    protected ShopContentDisplay_Component[] ContentDisplayComponents;

    protected List<ProductParams> SentProducts;

    public void TrySendProductsData()
    {
        if (SentProducts == null || ContentDisplayComponents == null || ContentDisplayComponents.Length == 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedDisplayComponent in ContentDisplayComponents)
        {
            if (!selectedDisplayComponent)
            {
                Debug.LogWarning("Missing arguments");
                continue;
            }
            if (!selectedDisplayComponent.gameObject.activeInHierarchy) continue;

            foreach (var selectedProduct in SentProducts)
            {
                selectedDisplayComponent.TryDisplayProductCard(selectedProduct);
            }
        }
    }

    protected virtual void TrySetSentProducts()
    {
    }

    #region Initialization

    protected virtual void Awake()
    {
        ContentDisplayComponents = FindObjectsOfType<ShopContentDisplay_Component>();
        TrySetSentProducts();
    }

    #endregion
}
