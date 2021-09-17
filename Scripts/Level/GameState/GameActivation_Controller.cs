using UnityEngine;

public class GameActivation_Controller : MonoBehaviour
{
    private GameState_Component _gameStateComponent;
    
    private void Update()
    {
        TryStartGame();
    }

    private void TryStartGame()
    {
        if (!_gameStateComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        if (!PlayerInput.HasActiveInput) return;

        if (_gameStateComponent.CurrentGameState == GameState.Warmup)
        {
            _gameStateComponent.TryStartGame();
        }
        else
        {
            ObjectDestroyer.TryDestroyObject(this);
        }
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _gameStateComponent);
    }

    #endregion
}
