using UnityEngine;

public class OnProductInitializerInstantiated_EventHandler : MonoBehaviour
{
    private PlayerSelectedProducts_Data _selectedProductsData;
    
    private AllProductInitializersRequestSender_Component _allProductInitializersRequestSender;
    
    private void HandleEvent(object s, ProductInitializerEventArgs args)
    {
        if (!_allProductInitializersRequestSender || !_selectedProductsData || _selectedProductsData.SelectedProducts == null
        || !args.ProductInitializerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _allProductInitializersRequestSender.TryAddProductInitializer(args.ProductInitializerComponent);

        // TODO possible work without it
        foreach (var selectedProduct in _selectedProductsData.SelectedProducts)
        {
            if (!selectedProduct)
            {
                Debug.LogWarning("Missing components");
                return;
            }
            
            args.ProductInitializerComponent.TryInitializeNewProduct(selectedProduct);
        }
    }

    #region State Change Reactions

    private void OnDisable()
    {
        ProductInitializer_Component.OnProductInitializerInstantiated -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _allProductInitializersRequestSender);
        _selectedProductsData = FindObjectOfType<PlayerSelectedProducts_Data>();
        ProductInitializer_Component.OnProductInitializerInstantiated += HandleEvent;
    }

    #endregion
}
