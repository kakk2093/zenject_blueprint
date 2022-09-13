using UnityEngine;
using Zenject;

public class EnemyFactory : IEnemyFactory
{
    private const string MeleeEnemyPrefabPath = "Enemy/EnemyMele";
    private const string RangedEnemyPrefabPath = "Enemy/EnemyRange";

    private GameObject _meleeEnemyPrefab;
    private GameObject _rangedEnemyPrefab;

    private readonly DiContainer _diContainer;

    public EnemyFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Create(EnemyType type, Vector3 at)
    {
        switch (type)
        {
            case EnemyType.Melle:
                _diContainer.InstantiatePrefab(_meleeEnemyPrefab, at, Quaternion.identity, null);
                break;
            case EnemyType.Range:
                _diContainer.InstantiatePrefab(_rangedEnemyPrefab, at, Quaternion.identity, null);
                break;
        }
    }

    public void Load()
    {
        _meleeEnemyPrefab = Resources.Load(MeleeEnemyPrefabPath) as GameObject;
        _rangedEnemyPrefab = Resources.Load(RangedEnemyPrefabPath) as GameObject;
    }
}