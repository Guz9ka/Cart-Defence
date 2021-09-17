using SWS;
using UnityEngine;

public class MaxCartProgress_Setter : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out CartProgress_Component cartProgressComponent);
        SplineMove cartMove = null;
        
        var cart = FindObjectOfType<Cart_Data>();
        if (cart)
        {
            cart.TryGetComponent(out cartMove);
        }

        if (!cartProgressComponent || !cartMove || !cartMove.pathContainer || cartMove.pathContainer.waypoints == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var pathLength = cartMove.pathContainer.waypoints.Length;
        cartProgressComponent.TrySetMaxProgress(pathLength);
    }
}
