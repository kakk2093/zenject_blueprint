using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProgresLevelViewer : MonoBehaviour
{
    [SerializeField] private Image _prorgesFillImage;

    private Transform _finisher;
    private Transform _player;
    private Vector3 _endPointPosition;
    private Vector3 _startPointPosition;
    private float _fullDistance;


    [Inject] 
    private void Construct(Player player, TestFinisher finisher)
    {
        _player = player.transform;
        _finisher = finisher.transform;
    }

    private void Start()
    {

        _endPointPosition = _finisher.position;
        _startPointPosition = _player.position;
        _fullDistance = Vector3.Distance(_startPointPosition, _endPointPosition);
    }

    private void Update()
    {
        if (_player.position.z <= _finisher.position.z && _player.position.z >= _startPointPosition.z)
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
