using System.Collections;
using UnityEngine;

public class Spawner_Component : MonoBehaviour
{
    [SerializeField] protected float SpawnTime;
    [SerializeField] protected int SpawnAmount;

    public void TriggerSpawn()
    {
        StartCoroutine(TryStartSpawning());
    }
    
    protected virtual IEnumerator TryStartSpawning()
    {
        yield break;
        
        // for (int i = 0; i < spawnAmount; i++)
        // {
        //     yield return new WaitForSeconds(spawnTime);
        //
        //     ObjectSpawner.TrySpawnObject(objectToSpawn, transform.position, transform.rotation);
        // }
    }
}
