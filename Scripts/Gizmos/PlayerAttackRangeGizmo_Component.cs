using UnityEngine;

public class PlayerAttackRangeGizmo_Component : MonoBehaviour
{
    [SerializeField] private Transform attackGizmoTransform;
    
    void Start()
    {
        if (!attackGizmoTransform)
        {
            Debug.Log("Missing components");
            return;
        }
        
        var playerData = GetComponentInParent<Player_Data>();
        if (!playerData || !playerData.PlayerParams)
        {
            Debug.Log("Missing components");
            return;
        }

        var attackRadius = playerData.PlayerParams.LookAtEnemyDistance;
        var attackDiameter = attackRadius * 2;
        
        attackGizmoTransform.localScale = new Vector3(attackDiameter, attackGizmoTransform.localScale.y, attackDiameter);
    }
}
