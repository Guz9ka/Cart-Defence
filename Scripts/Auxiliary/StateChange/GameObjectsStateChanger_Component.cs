using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsStateChanger_Component : MonoBehaviour
{
    public event EventHandler<BoolEventArgs> OnStateChanged;
    
    [SerializeField] private List<GameObject> gameObjectsChain;

    [SerializeField] private bool disableOnStart;
    [SerializeField] private bool disableOnAwake;

    public void ChangeGameObjectsStates(bool newState)
    {
        if (gameObjectsChain == null || gameObjectsChain.Count == 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedGameObject in gameObjectsChain)
        {
            if (!selectedGameObject)
            {
                Debug.LogWarning("Missing components");
                continue;
            }
            
            selectedGameObject.SetActive(newState);
        }

        NotifyObjectsStateChanged(newState);
    }

    #region Auxiliary

    private void NotifyObjectsStateChanged(bool newState)
    {
        var args = new BoolEventArgs
        {
            BoolValue = newState
        };
        OnStateChanged?.Invoke(this, args);
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        if (disableOnStart)
        {
            ChangeGameObjectsStates(false);
        }
    }
    
    private void Awake()
    {
        if (disableOnAwake)
        {
            ChangeGameObjectsStates(false);
        }
    }

    #endregion
}
