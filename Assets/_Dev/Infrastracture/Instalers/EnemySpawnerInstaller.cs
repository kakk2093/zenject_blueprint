using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private List<EnemySpawnMarker> _enemySpawnMarker;

    public override void InstallBindings()
    {
        BindEnemySpawnerInstaller();
        BindEnemyFactory();
    }

    private void BindEnemyFactory()
    {
        Container.
            Bind<IEnemyFactory>().
            To<EnemyFactory>().
            AsSingle();
    }
    private void BindEnemySpawnerInstaller()
    {
        Container.
            BindInterfacesTo<EnemySpawnerInstaller>().
            FromInstance(this);
    }

    public void Initialize()
    {
        EnemyFactoryInitialize();
    }

    private void EnemyFactoryInitialize()
    {
        var enemyFactory = Container.Resolve<IEnemyFactory>();
        enemyFactory.Load();

        foreach (EnemySpawnMarker marker in _enemySpawnMarker)
            enemyFactory.Create(marker.EnemyType, marker.transform.position);
    }
}
