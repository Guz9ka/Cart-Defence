using UnityEngine;

public class LevelRestartButtonSubscriber_Component : ButtonSubscriber_Component
{
    private LevelChanger_Component _levelChangerComponent;
    
    protected override void Subscribe()
    {
        if (!_levelChangerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        Button.onClick.AddListener(_levelChangerComponent.TryLoadCurrentLevel);
    }

    #region Initialization

    protected override void Start()
    {
        _levelChangerComponent = FindObjectOfType<LevelChanger_Component>();
        
        base.Start();
    }

    #endregion
}
