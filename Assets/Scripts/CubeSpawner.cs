using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private float scaleFactor = 0.5f;

    [SerializeField] private int minSpawn = 2;
    [SerializeField] private int maxSpawn = 6;

    public List<Cube> SpawnCubes(Transform parent, float newChance)
    {
        int count = Random.Range(minSpawn, maxSpawn + 1);

        List<Cube> result = new();

        Vector3 newScale = parent.localScale * scaleFactor;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = parent.position + Random.onUnitSphere * 0.5f;
            Quaternion rot = Random.rotation;

            Cube cube = Instantiate(_cubePrefab, pos, rot);

            cube.transform.localScale = newScale;

            cube.SetSplitChance(newChance);

            if (cube.TryGetComponent(out Renderer renderer))
                renderer.material.color = Random.ColorHSV();

            result.Add(cube);
        }

        return result;
    }
}
