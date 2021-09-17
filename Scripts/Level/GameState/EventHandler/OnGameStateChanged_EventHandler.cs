using UnityEngine;

public class OnGameStateChanged_EventHandler : MonoBehaviour
{
    private UIScreen_Component[] _uiScreenComponents;

    private GameState_Component _gameStateComponent;

    private void HandleEvent(object s, GameStateEventArgs args)
    {
        var newGameState = args.GameState;

        HandleGameStateChange(newGameState);
    }

    #region Main Actions

    private void HandleGameStateChange(GameState newState)
    {
        TryChangeStateOfAllActivatedByGameState(newState);
        TryChangeAllScreensState(newState);
    }

    #endregion

    #region Auxiliary Actions

    private void TryChangeStateOfAllActivatedByGameState(GameState newState)
    {
        foreach (var selectedObject in AffectedByGameStateObjects_Data.TryGetAffectedByGameStateObjects())
        {
            selectedObject.OnGameStateChanged(newState);
        }
    }

    private void TryChangeAllScreensState(GameState newState)
    {
        if (_uiScreenComponents == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedScreen in _uiScreenComponents)
        {
            if (!selectedScreen)
            {
                Debug.LogWarning("Missing components");
                continue;
            }

            selectedScreen.TryChangeScreenState(newState);
        }
    }

    #endregion

    #region State Change Reactions

    private void OnDisable()
    {
        if (_gameStateComponent)
        {
            _gameStateComponent.OnGameStateChanged -= HandleEvent;
        }
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _gameStateComponent))
        {
            _gameStateComponent.OnGameStateChanged += HandleEvent;
        }
        else
        {
            Debug.LogWarning("Missing components");
        }

        _uiScreenComponents = FindObjectsOfType<UIScreen_Component>();
    }

    #endregion
}