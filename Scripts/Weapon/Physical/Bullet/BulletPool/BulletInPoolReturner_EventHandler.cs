using UnityEngine;

public class BulletInPoolReturner_EventHandler : MonoBehaviour
{
    private BulletPool_Component _bulletPoolComponent;
    private BulletPoolFill_Controller _bulletPoolFillController;
    
    private void HandleEventPoolFiller(object s, BulletEventArgs args)
    {
        if (!args.BulletComponent) return;

        args.BulletComponent.OnHittedTarget += HandleEventBulletHit;
        args.BulletComponent.OnMissedTarget += HandleEventBulletHit;
    }

    private void HandleEventBulletHit(object s, BulletEventArgs args)
    {
        if (!_bulletPoolComponent || !args.BulletComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        
        _bulletPoolComponent.TryAddBulletToStack(args.BulletComponent);
    }

    #region State Change Reactions

    private void OnDisable()
    {
        if (_bulletPoolFillController)
        {
            _bulletPoolFillController.OnBulletSpawned -= HandleEventPoolFiller;
        }
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        if (TryGetComponent(out _bulletPoolFillController))
        {
            _bulletPoolFillController.OnBulletSpawned += HandleEventPoolFiller;
        }

        TryGetComponent(out _bulletPoolComponent);
    }

    #endregion
}
