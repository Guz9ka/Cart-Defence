using UnityEngine;

public class PlayerPosition_Data
{
    public static Transform PlayerTransform { get; private set; }

    public static void TrySetPlayerTransform(Transform playerTransform)
    {
        if (!playerTransform)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        PlayerTransform = playerTransform;
    }
}
