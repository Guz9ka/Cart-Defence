using UnityEngine;

public class ShopProductPriceDisplayer_Component : MonoBehaviour
{
    private TextDisplayer_Component _textDisplayerComponent;
    private GameObjectsStateChanger_Component _objectStateChangerComponent;
    private PlayerOwnedProducts_Data _playerOwnedProductsData;
    
    public void TryDisplay(ProductParams productToDisplay)
    {
        if (!productToDisplay)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var productIsOwned = TryCheckIfProductAlreadyOwned(productToDisplay);

        if (!productIsOwned)
        {
            TryChangePriceLabelState(true);
            TryDisplayPrice(productToDisplay.Price);
        }
        else
        {
            TryChangePriceLabelState(false);
        }
    }

    #region Available Actions

    private void TryChangePriceLabelState(bool newState)
    {
        if (!_objectStateChangerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _objectStateChangerComponent.ChangeGameObjectsStates(newState);
    }

    private void TryDisplayPrice(int price)
    {
        if (!_textDisplayerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _textDisplayerComponent.TryDisplayText(price.ToString());
    }

    private bool TryCheckIfProductAlreadyOwned(ProductParams productToCheck)
    {
        if (!_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return false;
        }

        return _playerOwnedProductsData.TryCheckIfProductOwned(productToCheck);
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _textDisplayerComponent);
        TryGetComponent(out _objectStateChangerComponent);

        _playerOwnedProductsData = FindObjectOfType<PlayerOwnedProducts_Data>();
    }

    #endregion
}
