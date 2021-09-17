using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvailableProductVisualAssociations", menuName = "Scriptable Objects/Shop/Product/Visual Associations/AvailableVisualAssociations",  order = 1)]
public class AvailableAssociatedVisualsParams : ScriptableObject
{
    [field: SerializeField] 
    public List<ProductVisualAssociationParams> ProductsVisualAssociations { get; private set; }
}
