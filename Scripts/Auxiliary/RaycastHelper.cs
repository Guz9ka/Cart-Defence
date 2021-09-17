using System.Collections.Generic;
using UnityEngine;

public class RaycastHelper : MonoBehaviour
{
    #region Sphere Checking

    public static bool CheckSpherePresence<T>(Vector3 position, float radius, LayerMask mask)
    {
        var isHitted = Physics.CheckSphere(position, radius, mask);
        return isHitted;
    }

    public static T[] TryFindObjectsSphere<T>(Vector3 startPosition, float radius, LayerMask mask)
    {
        var foundColliders = Physics.OverlapSphere(startPosition, radius, mask);
        if (foundColliders == null || foundColliders.Length <= 0) return default;

        var foundComponents = TryGetComponentsFromColliders<T>(foundColliders);
        return foundComponents;
    }

    public static T TryFindObjectSphere<T>(Vector3 startPosition, float radius, LayerMask mask)
    {
        var foundColliders = TryFindObjectsSphere<T>(startPosition, radius, mask);
        if (foundColliders == null || foundColliders.Length <= 0) return default;

        return foundColliders[0];
    }

    #endregion

    public static T TryFindObject<T>(Ray ray, LayerMask mask)
    {
        return TryFindObject<T>(ray.origin, ray.direction, Mathf.Infinity, mask);
    }
    
    public static T TryFindObject<T>(Vector3 startPoint, Vector3 direction, float length, LayerMask mask)
    {
        Physics.Raycast(startPoint, direction, out var hitInfo, length, mask);
        Debug.DrawRay(startPoint, direction * 100, Color.blue, 5);
        
        if (!hitInfo.collider) return default;

        var foundComponent = hitInfo.collider.GetComponent<T>();
        return foundComponent;
    }

    #region Auxiliary

    private static T[] TryGetComponentsFromColliders<T>(Collider[] foundColliders)
    {
        var foundComponents = new List<T>();
        foreach (var selectedCollider in foundColliders)
        {
            if (!selectedCollider) continue;
            
            var component = selectedCollider.GetComponent<T>();
            if (component == null) continue;
            
            foundComponents.Add(component);
        }

        return foundComponents.ToArray();
    }

    #endregion
}
