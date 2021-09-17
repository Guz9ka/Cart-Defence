using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static T TrySpawnObject<T>(MonoBehaviour objectToSpawn, Vector3 position, Quaternion rotation)
    {
        if (!objectToSpawn) return default;

        var instance = Instantiate(objectToSpawn, position, rotation);
        return instance.GetComponent<T>();
    }
    
    public static GameObject TrySpawnObject(GameObject objectToSpawn, Vector3 position, Quaternion rotation)
    {
        if (!objectToSpawn) return null;

        var instance = Instantiate(objectToSpawn, position, rotation);
        return instance;
    }
}
