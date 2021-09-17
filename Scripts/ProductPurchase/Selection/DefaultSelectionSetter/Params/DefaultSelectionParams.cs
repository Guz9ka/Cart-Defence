using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultSelectedProductsParams", menuName = "Scriptable Objects/Shop/DefaultSelectedProductsParams")]
public class DefaultSelectionParams : ScriptableObject
{
    [field:SerializeField] public List<ProductParams> DefaultSelectedProducts { get; private set; }
}
