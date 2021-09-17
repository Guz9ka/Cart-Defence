using UnityEngine;

public class NearbyPlayerSearch_Component : MonoBehaviour
{
    private float _activationRadius;
    
    public Player_Indicator TryGetPlayerNearby()
    {
        var foundPlayer = RaycastHelper.TryFindObjectSphere<Player_Indicator>(transform.position, _activationRadius, 
            Globals.LayerMaskPlayer);

        return foundPlayer;
    }

    #region Fields Setting

    public void TrySetActivationRadius(float activationRadius)
    {
        if (activationRadius < 0) return;

        _activationRadius = activationRadius;
    }

    #endregion
}
