using UnityEngine;
using SWS;

public class OnNextPointReached_EventHandler : MonoBehaviour
{
    private CartProgress_Component _cartProgressComponent;
    
    private SplineMove _splineMove;
    
    private void HandleEvent(int pointIndex)
    {
        if (!_cartProgressComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _cartProgressComponent.UpdateCurrentProgress();
        _cartProgressComponent.NotifyProgressChanged();
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_splineMove)
        {
            _splineMove.OnNextPointReached -= HandleEvent;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _splineMove))
        {
            _splineMove.OnNextPointReached += HandleEvent;
        }

        _cartProgressComponent = FindObjectOfType<CartProgress_Component>();
    }

    #endregion
}
