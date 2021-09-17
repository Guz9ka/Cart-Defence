using UnityEngine;

public class LevelProgressDisplay_Controller : MonoBehaviour
{
    private LevelProgressDisplay_Component _progressDisplayComponent;
    private LevelChanger_Component _levelChangerComponent;

    private void TriggerLevelDisplay()
    {
        if (!_levelChangerComponent || !_progressDisplayComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var currentLevelID = _levelChangerComponent.CurrentLevelID;
        _progressDisplayComponent.TryDisplayLevelProgress(currentLevelID);
    }

    #region Initialization

    // Start method is used because the LevelChanger appears on scene after loading as a DontDestroyOnLoad gameobject
    private void Start()
    {
        _levelChangerComponent = FindObjectOfType<LevelChanger_Component>();
        TriggerLevelDisplay();
    }

    private void Awake()
    {
        TryGetComponent(out _progressDisplayComponent);
    }

    #endregion
}
