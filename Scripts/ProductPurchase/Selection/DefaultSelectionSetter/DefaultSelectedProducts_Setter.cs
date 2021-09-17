using UnityEngine;

public class DefaultSelectedProducts_Setter : MonoBehaviour
{
    private PlayerSelectedProducts_Data _playerSelectedProductsData;
    private DefaultSelectedProducts_Data _defaultSelectedProductsData;

    private void Start()
    {
        if (!_defaultSelectedProductsData || _playerSelectedProductsData.SelectedProducts == null 
            || !_defaultSelectedProductsData.DefaultSelectionParams || !_playerSelectedProductsData
            || _defaultSelectedProductsData.DefaultSelectionParams.DefaultSelectedProducts == null
            || _defaultSelectedProductsData.DefaultSelectionParams.DefaultSelectedProducts.Count <= 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (_playerSelectedProductsData.SelectedProducts.Count > 0) return;

        foreach (var selectedProduct in _defaultSelectedProductsData.DefaultSelectionParams.DefaultSelectedProducts)
        {
            if (!selectedProduct)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            
            _playerSelectedProductsData.TrySelectNewProduct(selectedProduct);
        }
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _defaultSelectedProductsData);
        TryGetComponent(out _playerSelectedProductsData);
    }

    #endregion
}
