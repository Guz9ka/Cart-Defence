using System.Collections.Generic;
using UnityEngine;

public class LevelProgressDisplay_Component : MonoBehaviour
{
    [SerializeField] private List<LevelIndicator_Component> levelIndicators;

    public void TryDisplayLevelProgress(int currentLevelID)
    {
        if (levelIndicators == null || levelIndicators.Count < currentLevelID)
        {
            Debug.LogWarning("Wrong value or missing components");
            return;
        }

        var levelsCountToActivate = GetLevelCountToDisplay(currentLevelID, levelIndicators.Count);
        ActivateIndicators(levelsCountToActivate);   
    }

    #region Available Actions

    private void ActivateIndicators(int activeLevelID)
    {
        activeLevelID -= 1;
        
        for (var i = 0; i < levelIndicators.Count; i++)
        {
            var selectedLevelIndicator = levelIndicators[i];
            if (!selectedLevelIndicator) continue;

            if (i < activeLevelID)
            {
                selectedLevelIndicator.TryActivateIndicator(IndicatorTypes.Completed);
            }
            else if (i == activeLevelID)
            {
                selectedLevelIndicator.TryActivateIndicator(IndicatorTypes.Active);
            }
            else
            {
                selectedLevelIndicator.TryActivateIndicator(IndicatorTypes.Locked);
            }
        }
    }

    #endregion

    #region Auxiliary

    private int GetLevelCountToDisplay(int currentLevelID, int maximumLevelsToDisplay)
    {
        var countToDisplay = currentLevelID % maximumLevelsToDisplay;
        return countToDisplay;
    }

    #endregion
}
