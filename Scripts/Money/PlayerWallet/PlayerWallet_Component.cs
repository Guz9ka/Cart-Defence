using System;
using UnityEngine;

public class PlayerWallet_Component : MonoBehaviour
{
    public event EventHandler<IntEventArgs> OnBalanceChanged;
    public int CurrentBalance { get; private set; }

    public bool TryChangeWalletBalance(int amountToChange)
    {
        if (CurrentBalance + amountToChange < 0)
        {
            Debug.Log("Operation can not be processed");
            return false;
        }

        CurrentBalance += amountToChange;
        NotifyBalanceChanged();
        
        return true;
    }

    #region Auxiliary

    private void NotifyBalanceChanged()
    {
        Debug.Log("Balance was changed");
        
        var args = new IntEventArgs
        {
            Value = CurrentBalance
        };
        OnBalanceChanged?.Invoke(this, args);
    }

    #endregion
    
    private void Start()
    {
        TryChangeWalletBalance(10000);
    }
}
