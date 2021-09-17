using System.Collections.Generic;
using UnityEngine;

public class BulletPool_Component : MonoBehaviour
{
    private Stack<PhysicalBullet_Component> _bulletComponents;

    public void TryAddBulletToStack(PhysicalBullet_Component bulletComponent)
    {
        if (!bulletComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        bulletComponent.gameObject.SetActive(false);
        bulletComponent.TryStop();
        
        _bulletComponents.Push(bulletComponent);
    }

    public PhysicalBullet_Component TryGetBulletFromStack(Transform spawnTransform)
    {
        var bullet = TryGetBulletFromStack();
        if (!bullet) return null;

        bullet.transform.position = spawnTransform.position;
        bullet.transform.rotation = spawnTransform.rotation;

        return bullet;
    }

    #region Available Actions

    public PhysicalBullet_Component TryGetBulletFromStack()
    {
        var bullet = _bulletComponents.Pop();
        if (!bullet)
        {
            Debug.LogWarning("Null component");
            return null;
        }
        
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        if (_bulletComponents == null)
        {
            _bulletComponents = new Stack<PhysicalBullet_Component>();
        }
    }

    #endregion
}
