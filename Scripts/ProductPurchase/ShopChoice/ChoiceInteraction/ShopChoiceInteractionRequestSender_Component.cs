using UnityEngine;

public class ShopChoiceInteractionRequestSender_Component : MonoBehaviour
{
    protected ShopChoice_Data ShopChoiceData;
    
    public virtual void SendRequest() { }

    #region Initialization

    protected virtual void Awake()
    {
        ShopChoiceData = FindObjectOfType<ShopChoice_Data>();
    }

    #endregion
}
