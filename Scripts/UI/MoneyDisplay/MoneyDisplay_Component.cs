using TMPro;
using UnityEngine;

public class MoneyDisplay_Component : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    public void TryDisplayNewValue(int newValue)
    {
        if (!label)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var formattedValue = ValueFormatter.KiloFormat(newValue);
        label.text = formattedValue;
    }
}
