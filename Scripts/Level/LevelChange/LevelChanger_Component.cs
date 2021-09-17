using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger_Component : MonoBehaviour
{
    public int CurrentLevelID { get; private set; } = Globals.FirstLevelID;

    public void TryLoadCurrentLevel()
    {
        TryLoadLevel(CurrentLevelID);
    }

    #region Available Actions

    private void TryLoadLevel(int loadedLevelID)
    {
        if (SceneManager.sceneCountInBuildSettings < loadedLevelID) return;

        SceneManager.LoadScene(loadedLevelID);
    }

    #endregion

    #region Fields Setting

    public void SetNextLevelAsCurrent()
    {
        CurrentLevelID += 1;
    }

    #endregion
}
