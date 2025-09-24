using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _splitChanceDecayFactor = 0.5f;
    [SerializeField] private float _spawnOffsetRadius = 0.5f;

    [SerializeField] private int _minSpawnCount = 2;
    [SerializeField] private int _maxSpawnCount = 6;

    private int _spawnCountAdd = 1;

    public List<Cube> SpawnCubes(Transform parent, float currentChance)
    {
        List<Cube> spawnedCubes = new();

        Vector3 newScale = parent.localScale * _scaleFactor;

        int spawnCount = Random.Range(_minSpawnCount, _maxSpawnCount + _spawnCountAdd);

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = parent.position + Random.onUnitSphere * _spawnOffsetRadius;
            Quaternion spawnRotation = Random.rotation;

            Cube cube = Instantiate(_cubePrefab, spawnPosition, spawnRotation);
            cube.transform.localScale = newScale;

            cube.SetSplitChance(currentChance * _splitChanceDecayFactor);

            if (cube.TryGetComponent(out Renderer renderer))
                renderer.material.color = Random.ColorHSV();

            spawnedCubes.Add(cube);
        }

        return spawnedCubes;
    }
}
