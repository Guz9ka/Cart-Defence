using UnityEngine;

public class LevelIndicator_Component : MonoBehaviour
{
    [SerializeField] private GameObject activeIndicator;
    [SerializeField] private GameObject completedIndicator;
    [SerializeField] private GameObject lockedIndicator;
    
    public void TryActivateIndicator(IndicatorTypes indicatorTypes)
    {
        if (!activeIndicator || !completedIndicator || !lockedIndicator)
        {
            Debug.LogWarning("Missing components");
            return;
        } 
        
        switch (indicatorTypes)
        {
            case IndicatorTypes.Active:
                activeIndicator.SetActive(true);
                break;
            case IndicatorTypes.Completed:
                completedIndicator.SetActive(true);
                break;
            case IndicatorTypes.Locked:
                lockedIndicator.SetActive(true);
                break;
        }
    }

    #region Initialization

    private void Awake()
    {
        if (!activeIndicator || !completedIndicator || !lockedIndicator)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        activeIndicator.SetActive(false);
        completedIndicator.SetActive(false);
        lockedIndicator.SetActive(false);
    }

    #endregion
}

