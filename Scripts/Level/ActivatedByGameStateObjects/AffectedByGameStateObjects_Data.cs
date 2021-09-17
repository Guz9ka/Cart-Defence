using System.Linq;
using UnityEngine;

public class AffectedByGameStateObjects_Data : MonoBehaviour
{
    public static IAffectedByGameStateObject[] TryGetAffectedByGameStateObjects()
    {
        return FindObjectsOfType<MonoBehaviour>().OfType<IAffectedByGameStateObject>().ToArray();
    }
}
