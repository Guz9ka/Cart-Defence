using System.Collections;
using UnityEngine;

public class MovementComponentRandomPositionSpawner_Component : Spawner_Component
{
    [SerializeField] private Movement_Component movementComponentToSpawn;
    [SerializeField] private float spawnRadius;
    
    protected override IEnumerator TryStartSpawning()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            yield return new WaitForSeconds(SpawnTime);

            var randomSpawnPosition = GetRandomSpawnPosition();
            var spawnedMovementComponent = ObjectSpawner.TrySpawnObject<Movement_Component>(movementComponentToSpawn, 
                randomSpawnPosition, transform.rotation);
            if (!spawnedMovementComponent) yield break;
            
            spawnedMovementComponent.TryChangeActivityState(true);
        }
    }

    #region Auxiliary

    private Vector3 GetRandomSpawnPosition()
    {
        var randomX = Random.Range(-spawnRadius, spawnRadius);
        var randomY = Random.Range(-spawnRadius, spawnRadius);

        var randomSpawnPosition = new Vector3(randomX, randomY, 0);
        return randomSpawnPosition + transform.position;
    }

    #endregion
}
