using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product_Data : MonoBehaviour
{
    [field: SerializeField] public ProductParams ProductParams { get; private set; }

    public void SetProductParams(ProductParams newProductParams)
    {
        ProductParams = newProductParams;
    }
}
