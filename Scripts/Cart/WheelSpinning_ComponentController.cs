using System;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpinning_ComponentController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 rotationDirection;

    [SerializeField] private List<Transform> wheels;
    
    private CartMovement_Component _cartMovementComponent;

    private void Update()
    {
        foreach (var selectedWheel in wheels)
        {
            if (!selectedWheel)
            {
                Debug.LogWarning("Missing components");
                continue;
            }

            var desiredRotation = rotationDirection * (_cartMovementComponent.CurrentCartSpeed * rotationSpeed);
            desiredRotation *= Time.deltaTime;

            var newRotation = selectedWheel.transform.rotation.eulerAngles + desiredRotation;
            selectedWheel.rotation = Quaternion.Euler(newRotation);
        }
    }

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _cartMovementComponent);
    }

    #endregion
}
