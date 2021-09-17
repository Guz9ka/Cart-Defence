using UnityEngine;

public class OnCartProgressChanged_EventHandler : MonoBehaviour
{
    private CartProgress_Component _cartProgressComponent;
    private CartProgressDisplayer_Component _cartProgressDisplayerComponent;
    
    private void HandleEvent(float currentProgress)
    {
        if (!_cartProgressDisplayerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _cartProgressDisplayerComponent.TryDisplayProgress(currentProgress);
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_cartProgressComponent)
        {
            _cartProgressComponent.OnCartProgressChanged -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _cartProgressComponent))
        {
            _cartProgressComponent.OnCartProgressChanged += HandleEvent;
        }

        _cartProgressDisplayerComponent = FindObjectOfType<CartProgressDisplayer_Component>();
    }

    #endregion
}
