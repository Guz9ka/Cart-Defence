using System;
using UnityEngine;

public class ProductInitializer_Component : MonoBehaviour
{
    public static event EventHandler<ProductInitializerEventArgs> OnProductInitializerInstantiated;
    
    [field: SerializeField] public ProductType InitializedProductType { get; private set; }
    public GameObject InitializedProduct { get; private set; }
    
    
    public void TryInitializeNewProduct(ProductParams newProductToInitialize)
    {
        if (!newProductToInitialize)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (newProductToInitialize.ProductType != InitializedProductType) return;
     
        TryDestroyAlreadyInitializedProduct();
        TrySpawnNewProduct(newProductToInitialize.ProductPrefab);
    }

    #region Available Actions

    public void TryDestroyAlreadyInitializedProduct()
    {
        if (!InitializedProduct) return;
        
        ObjectDestroyer.TryDestroyObject(InitializedProduct.gameObject);
    }

    public void TrySpawnNewProduct(GameObject newProductToSpawn)
    {
        if (!newProductToSpawn)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var spawnPosition = transform.position;
        var spawnRotation = transform.rotation;
        var spawnedProduct = ObjectSpawner.TrySpawnObject(newProductToSpawn, spawnPosition, spawnRotation);
        if (!spawnedProduct)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        var newParent = transform.parent;
        spawnedProduct.transform.SetParent(newParent);

        InitializedProduct = spawnedProduct;
    }

    #endregion

    #region Auxiliary

    private void NotifyProductInitializerSpawned()
    {
        var args = new ProductInitializerEventArgs
        {
            ProductInitializerComponent = this
        };
        OnProductInitializerInstantiated?.Invoke(this, args);
    }

    #endregion

    #region Initialization

    private void Start()
    {
        NotifyProductInitializerSpawned();
    }

    #endregion
}
