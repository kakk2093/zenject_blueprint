using UnityEngine;
using Zenject;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
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

