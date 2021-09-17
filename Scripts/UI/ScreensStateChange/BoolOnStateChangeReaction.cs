using System;
using UnityEngine;

[Serializable]
public class BoolOnStateChangeReaction
{
    [field: SerializeField] public GameState State { get; private set; }
    [field: SerializeField] public bool AssociatedBoolReaction { get; private set; }
    
}
