using UnityEngine;
using UnityEngine.UI;

public class ProductVisualDisplay_Component : MonoBehaviour
{
    private RawImage _imageDisplay;
    
    private ProductAssociatedVisuals_Data _productAssociatedVisualsData;
    
    public void TryDisplay(ProductParams productToDisplay)
    {
        var productVisuals = TryGetProductVisuals(productToDisplay);
        TryDisplayProductVisuals(productVisuals);
    }

    #region Available Actions

    private void TryDisplayProductVisuals(ProductVisualAssociationParams visualAssociationParams)
    {
        if (!visualAssociationParams || !_imageDisplay || !visualAssociationParams.AssociatedImage)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _imageDisplay.texture = visualAssociationParams.AssociatedImage;
    }
    
    private ProductVisualAssociationParams TryGetProductVisuals(ProductParams productToDisplay)
    {
        if (!_productAssociatedVisualsData)
        {
            Debug.LogWarning("Missing components");
            return null;
        }

        var associatedVisuals = 
            _productAssociatedVisualsData.TryGetAssociatedVisual(productToDisplay);
        
        return associatedVisuals;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _imageDisplay);
        _productAssociatedVisualsData = FindObjectOfType<ProductAssociatedVisuals_Data>();
    }

    #endregion
}
