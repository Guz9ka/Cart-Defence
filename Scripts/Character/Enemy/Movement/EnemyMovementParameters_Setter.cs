using UnityEngine;

public class EnemyMovementParameters_Setter : MonoBehaviour
{
    private void Awake()
    {
        if (!TryGetComponent(out PlayerFollowing_Component enemyMovementComponent) || 
            !TryGetComponent(out Enemy_Data enemyData) || !enemyData.EnemyParams) return;

        enemyMovementComponent.SetMovementSpeed(enemyData.EnemyParams.MoveSpeed);
        enemyMovementComponent.TrySetStopDistance(enemyData.EnemyParams.StopFollowDistance);
        enemyMovementComponent.TrySetContinueDistance(enemyData.EnemyParams.ContinueFollowDistance);
    }
}
