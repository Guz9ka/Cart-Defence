using System;
using UnityEngine;

[Serializable]
public class MinMaxInt
{
    [field:SerializeField] public int Min { get; private set; }
    [field:SerializeField] public int Max { get; private set; }

    public void SetMinValue(int newValue)
    {
        Min = newValue;
    }
    
    public void SetMaxValue(int newValue)
    {
        Max = newValue;
    }
}
