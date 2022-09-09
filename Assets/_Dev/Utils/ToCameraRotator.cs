using UnityEngine;

public class ToCameraRotator : MonoBehaviour
{
    [SerializeField] private bool _updateRotation;

    private Camera _camera;
    private Transform _transform;

    private void Start()
    {
        _camera = Camera.main;
        _transform = transform;
        RefreshRotation();
    }

    private void LateUpdate()
    {
        if (_updateRotation)
            RefreshRotation();
    }

    private void RefreshRotation()
    {
        _transform.forward = _camera.transform.forward;
    }
}
