using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopParams", menuName = "Scriptable Objects/Shop/Shop Params", order = 0)]
public class ShopParams : ScriptableObject
{
    [field: SerializeField] public List<ProductParams> AvailableProducts { get; private set; }
}
