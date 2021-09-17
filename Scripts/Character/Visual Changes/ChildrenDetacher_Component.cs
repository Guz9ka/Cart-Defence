using System.Collections.Generic;
using UnityEngine;

public class ChildrenDetacher_Component : MonoBehaviour
{
    [SerializeField] private List<Transform> visuals;

    public void TryDetachChildren()
    {
        if (visuals == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedVisual in visuals)
        {
            if (!selectedVisual) continue;
            
            selectedVisual.SetParent(null);
        }
    }
}
