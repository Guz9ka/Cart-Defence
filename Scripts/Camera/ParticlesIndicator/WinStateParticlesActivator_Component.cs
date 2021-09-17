using UnityEngine;

public class WinStateParticlesActivator_Component : MonoBehaviour, IAffectedByGameStateObject
{
    private ParticleActivator_Component _cameraParticles;

    private void TryActivateParticles()
    {
        if (!_cameraParticles)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        _cameraParticles.TryPlayParticles();
    }

    #region State Change Reactions

    public void OnGameStateChanged(GameState newState)
    {
        if (newState != GameState.Win) return;
        
        TryActivateParticles();
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        _cameraParticles = GetComponent<ParticleActivator_Component>();
    }

    #endregion
}