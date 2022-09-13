using UnityEngine;
using Zenject;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;


    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        MoveToPoint(_player.transform);
    }

    private void MoveToPoint(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);
    }

    public class CubeFactory : PlaceholderFactory<Cube> { }
}
