using UnityEngine;
using UnityEngine.UI;

public class ButtonSubscriber_Component : MonoBehaviour
{
    protected Button Button;

    protected virtual void Subscribe()
    {
        
    }
    
    protected virtual void Start()
    {
        if (TryGetComponent(out Button))
        {
            Subscribe();
        }
        else
        {
            Debug.LogWarning("Missing components");
        }
    }
}
