using UnityEngine;
using UnityEngine.SceneManagement;

public class OnProductDeselected_EventHandler : MonoBehaviour
{
    private AllProductInitializersRequestSender_Component _allProductInitializersRequestSender;
    
    private PlayerSelectedProducts_Data _playerSelectedProductsData;
    
    private void HandleEvent(object s, ProductParamsEventArgs args)
    {
        if (!_allProductInitializersRequestSender || !args.ProductParams)
        {
            if (SceneManager.GetActiveScene().buildIndex == Globals.MainMenuSceneID) return;
            
            Debug.LogWarning("Missing components");
            return;
        }   
        
        
    }

    #region Auxiliary

    private void FindNewProductInitializer(Scene scene, LoadSceneMode loadMode)
    {
        _allProductInitializersRequestSender = FindObjectOfType<AllProductInitializersRequestSender_Component>();
    }

    #endregion
    
    #region State Change Reactions

    private void OnDisable()
    {
        if (_playerSelectedProductsData)
        {
            _playerSelectedProductsData.OnProductDeselected -= HandleEvent;
        }
        
        SceneManager.sceneLoaded -= FindNewProductInitializer;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _playerSelectedProductsData))
        {
            _playerSelectedProductsData.OnProductDeselected += HandleEvent;
        }

        SceneManager.sceneLoaded += FindNewProductInitializer;
    }

    #endregion
}
