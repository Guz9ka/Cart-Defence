using UnityEngine;

public class SpawnTrigger_Controller : MonoBehaviour
{
    [SerializeField] private Spawner_Component _spawnerComponent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!_spawnerComponent)
        {
            Debug.LogWarning("Missing components");
            return;
        }
        if (!other.GetComponent<Cart_Data>()) return;
        
        _spawnerComponent.TriggerSpawn();
    }
}
