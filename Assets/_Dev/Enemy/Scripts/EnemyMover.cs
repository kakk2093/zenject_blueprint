using UnityEngine;
using Zenject;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Player _player;
    private IGamePlayService _gamePlayService;

    [Inject]
    private void Construct(Player player, IGamePlayService gamePlayService)
    {
        _player = player;
        _gamePlayService = gamePlayService;

        _gamePlayService.GameStartEvent += OnGameStart;
    }

    private void OnDestroy()
    {
        _gamePlayService.GameStartEvent -= OnGameStart;
    }

    private void Start()
    {
        _speed = 0f;
    }

    private void OnGameStart()
    {
        _speed = 5f;
    }

    private void Update()
    {
        MoveToPosition(_player.transform);
    }

    private void MoveToPosition(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);
    }
}

