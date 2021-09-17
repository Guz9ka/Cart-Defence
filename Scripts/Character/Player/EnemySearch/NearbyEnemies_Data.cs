using UnityEngine;

public class NearbyEnemies_Data : MonoBehaviour
{
    public Enemy_Data NearestEnemy { get; private set; }
    public int EnemiesCount { get; private set; }
    
    [field: SerializeField] public NearbyEnemiesSearchParams SearchParams { get; private set; }

    #region Fields Setting

    public void SetNearestEnemy(Enemy_Data newNearestEnemy)
    {
        NearestEnemy = newNearestEnemy;
    }

    public void SetEnemiesCount(int count)
    {
        EnemiesCount = count;
    }

    #endregion
}
