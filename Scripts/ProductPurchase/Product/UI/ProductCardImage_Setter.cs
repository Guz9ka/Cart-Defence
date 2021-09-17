using UnityEngine;
using UnityEngine.UI;

public class ProductCardImage_Setter : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out RawImage cardImage);
        TryGetComponent(out Product_Data productData);
        var productAssociatedVisualsData = FindObjectOfType<ProductAssociatedVisuals_Data>();

        if (!cardImage || !productData || !productAssociatedVisualsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var associatedVisuals = productAssociatedVisualsData.TryGetAssociatedVisual(productData.ProductParams);
        if (!associatedVisuals || !associatedVisuals.AssociatedImage)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        cardImage.texture = associatedVisuals.AssociatedImage;
    }
}
