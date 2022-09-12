using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private TestFinisher _finisher;
  

    public override void InstallBindings()
    {
        BindFinisher();
        BindPlayer();
    }


    private void BindPlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint.position, Quaternion.identity, null);

        Container.
            Bind<Player>().
            FromInstance(player).AsSingle().
            NonLazy();
    }
    private void BindFinisher()
    {
        Container.
          Bind<TestFinisher>().
          FromInstance(_finisher).AsSingle().
          NonLazy();
    }
}
