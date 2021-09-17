using UnityEngine;

[CreateAssetMenu(fileName = "ProductParams", menuName = "Scriptable Objects/Shop/Product/Product Params", order = 0)]
public class ProductParams : ScriptableObject
{
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public ProductType ProductType { get; private set; }
    [field: SerializeField] public GameObject ProductPrefab { get; private set; }
}
