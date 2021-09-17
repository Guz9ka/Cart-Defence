using UnityEngine;

public class NearbyEnemiesDataSet_Controller : MonoBehaviour
{
    private PlayerPosition_Data _playerPositionData;
    private NearbyEnemies_Data _nearbyEnemiesData;

    private void Update()
    {
        if (!_nearbyEnemiesData)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        var nearbyEnemies = TryFindNearbyEnemies();
        if (nearbyEnemies == null)
        {
            _nearbyEnemiesData.SetEnemiesCount(0);
            _nearbyEnemiesData.SetNearestEnemy(null);
            return;
        }
        
        _nearbyEnemiesData.SetEnemiesCount(nearbyEnemies.Length);
        
        var nearestEnemy = TryGetNearestEnemy(nearbyEnemies);
        _nearbyEnemiesData.SetNearestEnemy(nearestEnemy);
    }

    #region Available Actions

    private Enemy_Data[] TryFindNearbyEnemies()
    {
        if (!_nearbyEnemiesData || !_nearbyEnemiesData.SearchParams || !PlayerPosition_Data.PlayerTransform)
        {
            Debug.LogWarning("Missing components");
            return null;
        }
        
        var searchParams = _nearbyEnemiesData.SearchParams;
        
        var playerPosition = PlayerPosition_Data.PlayerTransform.position;
        var foundEnemies = RaycastHelper.TryFindObjectsSphere<Enemy_Data>(playerPosition, searchParams.SearchDistance, 
            Globals.LayerMaskEnemy);

        return foundEnemies;
    }
    
    private Enemy_Data TryGetNearestEnemy(Enemy_Data[] foundEnemies)
    {
        if (foundEnemies == null || !foundEnemies[0]) return null;

        var nearestEnemy = foundEnemies[0];
        var minimumDistance = TryGetDistanceFromPlayerToEnemy(nearestEnemy.transform.position);

        foreach (var selectedEnemy in foundEnemies)
        {
            if (!nearestEnemy || nearestEnemy == selectedEnemy) continue;

            var currentDistance = TryGetDistanceFromPlayerToEnemy(selectedEnemy.transform.position);
            if (minimumDistance > currentDistance)
            {
                nearestEnemy = selectedEnemy;
                minimumDistance = currentDistance;
            }
        }

        return nearestEnemy;
    }

    #endregion
    
    #region Auxiliary

    private float TryGetDistanceFromPlayerToEnemy(Vector3 enemyPosition)
    {
        if (!PlayerPosition_Data.PlayerTransform)
        {
            Debug.LogWarning("Missing components");
            return 0;
        }
        
        var playerPosition = PlayerPosition_Data.PlayerTransform.position;
        
        var distanceToEnemy = VectorHelper.GetVectorsDistance(playerPosition, enemyPosition);
        return distanceToEnemy;
    }
    
    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _nearbyEnemiesData);
    }

    #endregion
}
