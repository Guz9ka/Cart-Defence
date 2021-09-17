using UnityEngine;

public class AllProductsInitialization_Controller : MonoBehaviour
{
    private AllProductInitializersRequestSender_Component _allProductInitializersRequestSender;
    private PlayerSelectedProducts_Data _playerSelectedProductsData;

    private void TryInitializeAllSelectedProducts()
    {
        if (!_allProductInitializersRequestSender || !_playerSelectedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var productsToInitialize = _playerSelectedProductsData.SelectedProducts;
        if (productsToInitialize == null || productsToInitialize.Count <= 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _allProductInitializersRequestSender.TrySendInitializationRequests(productsToInitialize.ToArray());
    }
    
    #region Initialization

    private void Start()
    {
        TryInitializeAllSelectedProducts();
    }

    private void Awake()
    {
        TryGetComponent(out _allProductInitializersRequestSender);
        _playerSelectedProductsData = FindObjectOfType<PlayerSelectedProducts_Data>();
    }

    #endregion
}
