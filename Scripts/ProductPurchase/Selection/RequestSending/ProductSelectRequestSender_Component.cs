using UnityEngine;

public class ProductSelectRequestSender_Component : MonoBehaviour
{
    private PlayerSelectedProducts_Data _playerSelectedProductsData;
    
    private ProductParams _sentProductParams;
    
    public void TrySelectProduct()
    {
        if (!_sentProductParams || !_playerSelectedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _playerSelectedProductsData.TrySelectNewProduct(_sentProductParams);
    }

    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out Product_Data productData))
        {
            _sentProductParams = productData.ProductParams;
        }

        _playerSelectedProductsData = FindObjectOfType<PlayerSelectedProducts_Data>();
    }

    #endregion
}
