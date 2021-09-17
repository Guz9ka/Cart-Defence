using System;
using UnityEngine;

public class CartFinalPointDetector_ComponentController : MonoBehaviour
{
    public event EventHandler OnFinalPointReached;

    [SerializeField] private float triggerDistance;

    private Cart_Data _cartData;

    private void Update()
    {
        if (!_cartData)
        {
            Debug.LogError("Missing component");
            return;
        }
        
        var distance = VectorHelper.GetVectorsDistance(transform.position, _cartData.transform.position);
        if (distance > triggerDistance) return;
        
        OnFinalPointReached?.Invoke(this, EventArgs.Empty);
        Debug.Log("Final point is reached!");
        
        ObjectDestroyer.TryDestroyObject(this);
    }

    #region Initialization

    private void Awake()
    {
        _cartData = FindObjectOfType<Cart_Data>();
    }

    #endregion
}
