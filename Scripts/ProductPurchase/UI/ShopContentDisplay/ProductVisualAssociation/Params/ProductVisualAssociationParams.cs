using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ProductVisualAssociation", menuName = "Scriptable Objects/Shop/Product/Visual Associations/ProductVisualAssociation",  order = 0)]
public class ProductVisualAssociationParams : ScriptableObject
{
    [field:SerializeField] public ProductParams Product { get; private set; }
    [field:SerializeField] public Texture2D AssociatedImage { get; private set; }
}
