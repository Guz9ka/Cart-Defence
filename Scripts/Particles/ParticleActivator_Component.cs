using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator_Component : MonoBehaviour
{
    [SerializeField] private string note = "Где используется эта партикл система";
    [SerializeField] private List<ParticleSystem> _particleSystems;

    public void TryPlayParticles()
    {
        if (_particleSystems == null || _particleSystems.Count == 0)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedParticleSystem in _particleSystems)
        {
            if (!selectedParticleSystem)
            {
                Debug.LogWarning("Missing components");
                return;
            }
            if (selectedParticleSystem.isPlaying) continue;
        
            selectedParticleSystem.Play();
        }
    }

    #region Initialization

    private void Start()
    {
        // Just to remove warning in console
        note = note + "!";
    }

    #endregion
}
