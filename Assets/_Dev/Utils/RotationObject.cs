using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _rotateX, _rotateY, _rotateZ;

    public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }

    private void YRotation()
    {
        transform.Rotate(new Vector3(0, RotationSpeed, 0) * Time.deltaTime);
    }
    private void ZRotation()
    {
        transform.Rotate(new Vector3(0, 0, RotationSpeed) * Time.deltaTime);
    }
    private void XRotation()
    {
        transform.Rotate(new Vector3(RotationSpeed, 0, 0) * Time.deltaTime);
    }

    private void Update()
    {
        if(_rotateY)
            YRotation();
        if (_rotateX)
            XRotation();
        if (_rotateZ)
            ZRotation();
    }
}
