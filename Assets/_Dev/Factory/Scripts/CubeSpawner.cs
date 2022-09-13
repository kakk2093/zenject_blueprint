using UnityEngine;
using Zenject;

public class CubeSpawner : MonoBehaviour
{
    private Cube.CubeFactory _cubeFactory;

    [Inject]
    private void Construct(Cube.CubeFactory cubeFactory)
    {
        _cubeFactory = cubeFactory;
    }

    private void Start()
    {
        SpawnCube();
    }

    private void SpawnCube()
    {
        Cube cube = _cubeFactory.Create();
        cube.transform.position = new Vector3(0, 0, 20);

    }
}
