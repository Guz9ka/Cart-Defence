using UnityEngine;

public class LookAtNearestEnemy_ComponentController : MonoBehaviour
{
    [SerializeField] private Vector3 rotationOffset;
    
    private int _rotationSpeed;
    private float _lookDistance;
    private NearbyEnemies_Data _nearbyEnemiesData;

    private void Update()
    {
        TryLookAtNearestEnemy();
    }

    private void TryLookAtNearestEnemy()
    {
        if (!_nearbyEnemiesData)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var nearestEnemy = _nearbyEnemiesData.NearestEnemy;

        if (TryLookAtEnemy(nearestEnemy)) return;
        if (TryLookAtInput()) return;
    }

    #region Available Actions

    private bool TryLookAtEnemy(Enemy_Data enemy)
    {
        if (!enemy) return false;
        
        var distanceToEnemy = VectorHelper.GetVectorsDistance(enemy.transform.position, transform.position);
        if (distanceToEnemy > _lookDistance) return false;
        
        LookAtPosition(enemy.transform.position);

        return true;
    }

    private bool TryLookAtInput()
    {
        if (!PlayerInput.HasActiveInput) return false;
        
        var moveDirection = new Vector3(PlayerInput.MoveDirection.x, 0, PlayerInput.MoveDirection.y);
        var lookPosition = transform.position + moveDirection;

        LookAtPosition(lookPosition);

        return true;
    }

    #endregion
    
    #region Auxiliary

    private void LookAtPosition(Vector3 lookPosition)
    {
        var rotationSpeed = _rotationSpeed * Time.deltaTime;
        
        var deltaPosition = lookPosition - transform.position;
        var desiredRotationEuler = Quaternion.LookRotation(deltaPosition).eulerAngles + rotationOffset;
        var desiredRotationQuaternion = Quaternion.Euler(desiredRotationEuler);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotationQuaternion, rotationSpeed);
    }

    #endregion

    #region Fields Setting

    public void SetRotationSpeed(int amount)
    {
        _rotationSpeed = amount;
    }

    public void TrySetLookDistance(float amount)
    {
        if (amount < 0) return;

        _lookDistance = amount;
    }

    #endregion

    #region Initialization

    private void Start()
    {
        _nearbyEnemiesData = FindObjectOfType<NearbyEnemies_Data>();
    }

    #endregion
}
