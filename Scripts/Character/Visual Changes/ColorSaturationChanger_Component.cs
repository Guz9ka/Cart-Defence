using System;
using UnityEngine;

public class ColorSaturationChanger_Component : MonoBehaviour
{
    // current saturation
    private Material _changedMaterial;
    // 0% saturation
    [SerializeField] private Material targetMaterial;
    
    // 100% saturation
    private Material _originalMaterial;

    public void TryChangeSaturation(int currentValue, int maxValue)
    {
        if (!_changedMaterial || !_originalMaterial || !targetMaterial)
        {
            Debug.LogWarning("Missing components!");
            return;
        }

        var progress = GetSaturationProgress(currentValue, maxValue);
        
        _changedMaterial.Lerp(_originalMaterial, targetMaterial, progress);
    }

    #region Auxiliary

    private float GetSaturationProgress(int currentValue, int maxValue)
    {
        var difference = (float) currentValue / maxValue;
        var progress = 1 - difference;
        
        return progress;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        var meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if (meshRenderer)
        {
            _changedMaterial = meshRenderer.material;   
            _originalMaterial = meshRenderer.material;
        }
    }

    #endregion
}
