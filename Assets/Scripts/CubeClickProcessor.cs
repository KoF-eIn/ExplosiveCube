using UnityEngine;

public class CubeClickProcessor : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    [SerializeField] private ExplosionService _explosion;

    [SerializeField] private CubeInputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler.OnCubeClicked += HandleCubeClick;
    }

    private void OnDestroy()
    {
        _inputHandler.OnCubeClicked -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            var spawned = _spawner.SpawnCubes(cube.transform, cube.SplitChance * 0.5f);

            _explosion.Explode(spawned, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}
