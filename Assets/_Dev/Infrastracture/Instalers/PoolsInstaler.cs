using UnityEngine;
using Zenject;

public class PoolsInstaler : MonoInstaller<PoolsInstaler>
{
    [SerializeField] private DefaultFx _defaultFxPrefab;

    public override void InstallBindings()
    {
        BindDefaultFxMemoryPool();
    }
    private void BindDefaultFxMemoryPool()
    {
        Container.
        BindMemoryPool<DefaultFx, DefaultFx.DefaultFxPool>().
            WithInitialSize(30).
            FromComponentInNewPrefab(_defaultFxPrefab);
    }
}
