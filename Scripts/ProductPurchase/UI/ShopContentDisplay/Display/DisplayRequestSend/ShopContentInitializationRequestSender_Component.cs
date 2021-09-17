using UnityEngine;

public class ShopContentInitializationRequestSender_Component : MonoBehaviour
{
    private ProductDataSender_Component[] _productDataSenders;

    public void TrySendContentDisplayRequest()
    {
        if (_productDataSenders == null)
        {
            Debug.LogWarning("Missing components");
        }
        
        if (_productDataSenders != null)
        {
            foreach (var selectedDataSender in _productDataSenders)
            {
                if (!selectedDataSender)
                {
                    Debug.LogWarning("Missing components");
                    continue;
                }
                
                selectedDataSender.TrySendProductsData();
            }
        }
    }
    
    #region Initialization

    private void Start()
    {
        TrySendContentDisplayRequest();
    }

    private void Awake()
    {
        _productDataSenders = FindObjectsOfType<ProductDataSender_Component>();
    }

    #endregion
}
