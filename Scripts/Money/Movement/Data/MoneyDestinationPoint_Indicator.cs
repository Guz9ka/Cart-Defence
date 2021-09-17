using UnityEngine;

// Скрипт, через который монеты берут точку в которую будут лететь.
public class MoneyDestinationPoint_Indicator : MonoBehaviour
{
    public static MoneyDestinationPoint_Indicator Instance { get; private set; }

    private void OnEnable()
    {
        if (Instance)
        {
            Debug.LogError("Two instances of singleton");
            return;
        }

        Instance = this;
    }

    private void OnDisable()
    {
        if (Instance != this)
        {
            return;
        }

        Instance = null;
    }
}
