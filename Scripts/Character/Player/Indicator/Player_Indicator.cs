using System;
using UnityEngine;

public class Player_Indicator : MonoBehaviour
{
    public static event EventHandler<PlayerIndicatorEventArgs> OnPlayerInstantiated;
    
    private void NotifyPlayerSpawned()
    {
        var args = new PlayerIndicatorEventArgs
        {
            PlayerIndicator = this
        };
        OnPlayerInstantiated?.Invoke(this, args);
    }
    
    private void Awake()
    {
        NotifyPlayerSpawned();
    }
}
