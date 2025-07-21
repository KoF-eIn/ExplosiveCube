using UnityEngine;
using System.Collections.Generic;

public class CubeClickProcessor : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    [SerializeField] private ExplosionService _explosion;

    [SerializeField] private float defaultSplitChance;
    [SerializeField] private float minSplitChance;

    private Dictionary<GameObject, float> _chances = new();

    private void Start()
    {
        FindObjectOfType<CubeInputHandler>().OnCubeClicked += HandleCubeClick;
    }

    private void HandleCubeClick(GameObject cube)
    {
        if (!_chances.TryGetValue(cube, out float chance))
            chance = defaultSplitChance;

        if (Random.value <= chance)
        {
            List<GameObject> spawned = _spawner.SpawnCubes(cube.transform, chance * 0.5f);
            _explosion.Explode(spawned, cube.transform.position);
        }

        _chances.Remove(cube);
        Destroy(cube);
    }

    public void RegisterNewCube(GameObject cube, float chance)
    {
        _chances[cube] = Mathf.Max(chance, minSplitChance);
    }
}
