using System;
using UnityEngine;

public class RotationReset_ComponentController : MonoBehaviour
{
    [SerializeField] private Vector3 activeAxis;
    
    private void Update()
    {
        transform.rotation = Quaternion.Euler(activeAxis);
    }

    private void Awake()
    {
        activeAxis = transform.rotation.eulerAngles;
    }
}
