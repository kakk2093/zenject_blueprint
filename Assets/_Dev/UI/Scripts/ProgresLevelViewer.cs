using UnityEngine;
using UnityEngine.UI;

public class ProgresLevelViewer : MonoBehaviour
{
    [SerializeField] private Image _prorgesFillImage;

    private Transform _finishLineControlRemove;
    private Transform _player;
    private Vector3 _endPointPosition;
    private Vector3 _startPointPosition;
    private float _fullDistance;

    private void Start()
    {
        // _player = FindObjectOfType<Player>().GetComponent<Transform>();
        //  _finishLineControlRemove = FindObjectOfType<FinishLineControlRemove>().GetComponent<Transform>();
        _endPointPosition = _finishLineControlRemove.position;//finisher transform
        _startPointPosition = _player.position;
        _fullDistance = Vector3.Distance(_startPointPosition, _endPointPosition);
    }

    private void Update()
    {
        if (_player.position.z <= _finishLineControlRemove.position.z && _player.position.z >= _startPointPosition.z)
        {
            float newDistance = GetDistance();
            float progresValue = Mathf.InverseLerp(_fullDistance, 0f, newDistance);
            UpdateProgresFill(progresValue);
        }
    }

    private void UpdateProgresFill(float value)
    {
        _prorgesFillImage.fillAmount = value;
    }

    private float GetDistance()
    {
        return Vector3.Distance(_player.transform.position, _endPointPosition);
        //   return (_endPointPosition - _player.position).sqrMagnitude;
    }
}
