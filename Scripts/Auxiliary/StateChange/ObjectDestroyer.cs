using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public static void TryDestroyObject(params GameObject[] gameobjectToDestroy)
    {
        foreach (var selectedGameObject in gameobjectToDestroy)
        {
            if (!selectedGameObject) continue;

            Destroy(selectedGameObject);
        }
    }

    public static void TryDestroyObject(params Component[] componentsToDestroy)
    {
        foreach (var selectedComponent in componentsToDestroy)
        {
            if (!selectedComponent) continue;
            
            Destroy(selectedComponent);
        }
    }
}
