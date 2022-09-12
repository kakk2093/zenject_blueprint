using UnityEngine;
using Zenject;


public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private UpdateMode _updateMode;
    [SerializeField] private FollowMode _followMode;
    [SerializeField] private bool _isMove;
    [SerializeField] private bool _isRotate;
    [SerializeField] private bool _isBossFollow;
    [SerializeField] private bool _isPlayerFollow;

    [Header("Lerp Settings")]
    [SerializeField] private float _speed = 1f;

    [Header("MoveTowards Settings")]
    [SerializeField] private float _maxDeltaPos;
    [SerializeField] private float _maxDeltaRot;

    private Transform _transform;


    [Inject]
    private void Construct(Player player)
    {
        _followTarget = player.transform;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_updateMode != UpdateMode.FIXEDUPDATE)
            return;

        Follow();
    }

    private void Update()
    {
        if (_updateMode != UpdateMode.UPDATE)
            return;

        Follow();
    }

    private void LateUpdate()
    {
        if (_updateMode != UpdateMode.LATEUPDATE)
            return;

        Follow();
    }

    private void Follow()
    {
        if (_isMove)
            MoveToTargetPosition();
        if (_isRotate)
            RotateToTargetRotation();
    }

    private void MoveToTargetPosition()
    {
        switch (_followMode)
        {
            case FollowMode.LERP:
                LerpMove();
                break;
            case FollowMode.SLERP:
                SlerpMove();
                break;
            case FollowMode.SLERPUNCLAMPED:
                SlerpUnclampedMove();
                break;
            case FollowMode.MOVETOWARDS:
                MoveTowards();
                break;
        }
    }

    private void RotateToTargetRotation()
    {
        switch (_followMode)
        {
            case FollowMode.LERP:
                LerpRotation();
                break;
            case FollowMode.SLERP:
                SlerpRotation();
                break;
            case FollowMode.SLERPUNCLAMPED:
                SlerpUnclampedRotation();
                break;
            case FollowMode.MOVETOWARDS:
                RotateTowards();
                break;
        }
    }

    private void LerpMove()
    {
        _transform.position = Vector3.Lerp(
            _transform.position,
            _followTarget.position,
            _speed * GetDeltaTime());
    }

    private void SlerpMove()
    {
        _transform.position = Vector3.Slerp(
            _transform.position,
            _followTarget.position,
            _speed * GetDeltaTime());
    }

    private void SlerpUnclampedMove()
    {
        _transform.position = Vector3.SlerpUnclamped(
            _transform.position,
            _followTarget.position,
            _speed * GetDeltaTime());
    }

    private void MoveTowards()
    {
        _transform.position = Vector3.MoveTowards(
            _transform.position,
            _followTarget.position,
            _maxDeltaPos * GetDeltaTime());
    }

    private void LerpRotation()
    {
        _transform.rotation = Quaternion.Lerp(
            _transform.rotation,
            _followTarget.rotation,
            _speed * GetDeltaTime());
    }

    private void SlerpRotation()
    {
        _transform.rotation = Quaternion.Slerp(
            _transform.rotation,
            _followTarget.rotation,
            _speed * GetDeltaTime());
    }

    private void SlerpUnclampedRotation()
    {
        _transform.rotation = Quaternion.SlerpUnclamped(
            _transform.rotation,
            _followTarget.rotation,
            _speed * GetDeltaTime());
    }

    private void RotateTowards()
    {
        _transform.rotation = Quaternion.RotateTowards(
            _transform.rotation,
            _followTarget.rotation,
            _maxDeltaRot * GetDeltaTime());
    }

    private float GetDeltaTime()
    {
        switch (_updateMode)
        {
            case UpdateMode.FIXEDUPDATE:
                return Time.fixedDeltaTime;
            case UpdateMode.UPDATE:
                return Time.deltaTime;
            case UpdateMode.LATEUPDATE:
                return Time.deltaTime;
            default:
                return Time.deltaTime;
        }
    }
}

public enum UpdateMode
{
    FIXEDUPDATE = 0,
    UPDATE = 1,
    LATEUPDATE = 2
}

public enum FollowMode
{
    LERP = 0,
    SLERP = 1,
    SLERPUNCLAMPED = 2,
    MOVETOWARDS = 3
}
