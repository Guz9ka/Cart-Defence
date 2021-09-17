using System;
using UnityEngine;

public class ProductAssociatedVisuals_Data : MonoBehaviour
{
    [SerializeField] private AvailableAssociatedVisualsParams _availableAssociatedVisuals;

    public ProductVisualAssociationParams TryGetAssociatedVisual(ProductParams productToFind)
    {
        if (!productToFind || !_availableAssociatedVisuals || _availableAssociatedVisuals.ProductsVisualAssociations == null)
        {
            Debug.LogWarning("Missing components");
            return null;
        }

        foreach (var selectedAssociatedVisual in _availableAssociatedVisuals.ProductsVisualAssociations)
        {
            if (!selectedAssociatedVisual)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            if (selectedAssociatedVisual.Product != productToFind) continue;

            return selectedAssociatedVisual;
        }

        return null;
    }
}
