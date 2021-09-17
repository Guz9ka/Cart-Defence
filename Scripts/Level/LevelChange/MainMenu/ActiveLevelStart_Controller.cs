using UnityEngine;

public class ActiveLevelStart_Controller : MonoBehaviour
{
    private void Start()
    {
        var levelChanger = FindObjectOfType<LevelChanger_Component>();
        if (!levelChanger) return;
        
        levelChanger.TryLoadCurrentLevel();
    }
}
