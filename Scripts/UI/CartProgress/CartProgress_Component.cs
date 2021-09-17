using System;
using UnityEngine;

public class CartProgress_Component : MonoBehaviour
{
    public event Action<float> OnCartProgressChanged;
    
    private int _maxProgress;
    private int _currentProgress;

    public void UpdateCurrentProgress()
    {
        _currentProgress += 1;
    }

    #region Auxiliary

    public void NotifyProgressChanged()
    {
        var progress = GetMultipliedProgress();
        OnCartProgressChanged?.Invoke(progress);
    }
    
    private float GetMultipliedProgress()
    {
        var progress = (float) _currentProgress / _maxProgress;
        return progress;
    }

    #endregion
    
    #region Fields Setting

    public void TrySetMaxProgress(int value)
    {
        if (value < 0)
        {
            Debug.LogWarning("Wrong value");
            return;
        }
        
        _maxProgress = value;
    }

    #endregion
}
