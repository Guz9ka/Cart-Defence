using System;
using UnityEngine;

[Serializable]
public class MinMaxVector3
{
    [field:SerializeField] public Vector3 Min { get; private set; }
    [field:SerializeField] public Vector3 Max { get; private set; }

    public void SetMinValue(Vector3 newValue)
    {
        Min = newValue;
    }
    
    public void SetMaxValue(Vector3 newValue)
    {
        Max = newValue;
    }
}
