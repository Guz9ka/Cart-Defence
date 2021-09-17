using UnityEngine;

public class PlayersOwnedProductsDataSend_Component : ProductDataSender_Component
{
    private PlayerOwnedProducts_Data _playerOwnedProductsData;

    protected override void TrySetSentProducts()
    {
        if (!_playerOwnedProductsData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        SentProducts = _playerOwnedProductsData.OwnedProducts;
    }

    #region Initialization

    protected override void Awake()
    {
        _playerOwnedProductsData = FindObjectOfType<PlayerOwnedProducts_Data>();
        base.Awake();
    }

    #endregion
}
