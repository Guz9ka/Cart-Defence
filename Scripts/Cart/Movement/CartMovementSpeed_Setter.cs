using SWS;
using UnityEngine;

public class CartMovementSpeed_Setter : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out Cart_Data cartData);
        TryGetComponent(out SplineMove splineMove);

        if (cartData && cartData.CartParams && splineMove)
        {
            var moveSpeed = cartData.CartParams.MovementSpeed;
            splineMove.ChangeSpeed(moveSpeed);
        }
        else
        {
            Debug.LogWarning("Missing components");
        }
    }
}
