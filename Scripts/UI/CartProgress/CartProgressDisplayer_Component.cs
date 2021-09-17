using UnityEngine;
using UnityEngine.UI;

public class CartProgressDisplayer_Component : MonoBehaviour
{
    private Slider _progressBar;

    public void TryDisplayProgress(float currentProgress)
    {
        if (!_progressBar)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _progressBar.value = currentProgress;
    }

    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _progressBar))
        {
            _progressBar.value = 0;
        }
    }

    #endregion
}
