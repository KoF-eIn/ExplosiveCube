using UnityEngine;

public class CubeClickProcessor : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    [SerializeField] private ExplosionService _explosionService;

    [SerializeField] private CubeInputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler.CubeClicked += HandleCubeClick;
    }

    private void OnDestroy()
    {
        _inputHandler.CubeClicked -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            var spawnedCubes = _spawner.SpawnCubes(cube.transform, cube.SplitChance);

            _explosionService.ExplodeLocal(spawnedCubes, cube.transform.position);
        }
        else
        {
            _explosionService.ExplodeArea(cube);
        }

        Destroy(cube.gameObject);
    }
}
