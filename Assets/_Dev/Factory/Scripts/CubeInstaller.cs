using UnityEngine;
using Zenject;

public class CubeInstaller : MonoInstaller<CubeInstaller>
{
    [SerializeField] private Cube _cubePrefab;

    public override void InstallBindings()
    {
        BindFactory();
    }

    private void BindFactory()
    {
        Container.
            BindFactory<Cube, Cube.CubeFactory>().
            FromComponentInNewPrefab(_cubePrefab).
            AsSingle();
    }
}
