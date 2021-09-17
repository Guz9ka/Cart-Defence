using System.Collections.Generic;
using UnityEngine;

public class UIScreen_Component : MonoBehaviour
{
    [field: SerializeField] public List<BoolOnStateChangeReaction> BoolOnStateChangeReactions { get; private set; }
    
    private GameObjectsStateChanger_Component _screenStateChanger;

    public void TryChangeScreenState(GameState newGameStateState)
    {
        var newState = TryGetNewActivityState(newGameStateState);
        TrySetNewActivityState(newState);
    }

    #region Main Actions

    private bool TryGetNewActivityState(GameState newGameStateState)
    {
        if (BoolOnStateChangeReactions == null)
        {
            Debug.LogWarning("Missing components");
            return false;
        }

        foreach (var selectedReaction in BoolOnStateChangeReactions)
        {
            if (selectedReaction == null)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            if (selectedReaction.State != newGameStateState) continue;

            return selectedReaction.AssociatedBoolReaction;
        }
        
        return false;
    }

    private void TrySetNewActivityState(bool newState)
    {
        if (!_screenStateChanger)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _screenStateChanger.ChangeGameObjectsStates(newState);
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _screenStateChanger);
    }

    #endregion
}
