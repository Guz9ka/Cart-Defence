using System;
using UnityEngine;

public class BulletPoolFill_Controller : MonoBehaviour
{
    public event EventHandler<BulletEventArgs> OnBulletSpawned;
    
    [SerializeField] private int prespawnAmount;

    private PhysicalBullet_Component _bulletToSpawn;
    private BulletPool_Component _bulletPoolComponent;

    private void TryFillStack()
    {
        if (!_bulletPoolComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        for (int i = 0; i < prespawnAmount; i++)
        {
            var spawnedBullet = ObjectSpawner.TrySpawnObject<PhysicalBullet_Component>(
                _bulletToSpawn, transform.position, Quaternion.identity);
            
            _bulletPoolComponent.TryAddBulletToStack(spawnedBullet);
            spawnedBullet.gameObject.SetActive(false);
            
            NotifyBulletSpawned(spawnedBullet);
        }
    }

    #region Auxiliary

    private void NotifyBulletSpawned(PhysicalBullet_Component spawnedBulletComponent)
    {
        var args = new BulletEventArgs
        {
            BulletComponent = spawnedBulletComponent
        };
        OnBulletSpawned?.Invoke(this, args);
    }

    #endregion
    
    #region Fields Setting

    public void TrySetBulletToSpawn(PhysicalBullet_Component newBullet)
    {
        if (!newBullet)
        {
            Debug.LogWarning("Components is null");
            return;
        }

        _bulletToSpawn = newBullet;
    }

    #endregion

    #region Initialization

    private void Start()
    {
        TryFillStack();
    }

    private void Awake()
    {
        TryGetComponent(out _bulletPoolComponent);
    }

    #endregion
}
