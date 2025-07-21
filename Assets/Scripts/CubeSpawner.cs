using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private float scaleFactor;

    [SerializeField] private int minSpawn;
    [SerializeField] private int maxSpawn;

    [SerializeField] private CubeClickProcessor _processor;

    public List<GameObject> SpawnCubes(Transform parent, float newChance)
    {
        List<GameObject> result = new();

        Vector3 newScale = parent.localScale * scaleFactor;

        int count = Random.Range(minSpawn, maxSpawn + 1);

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = parent.position + Random.onUnitSphere * 0.5f;
            Quaternion rot = Random.rotation;

            GameObject cube = Instantiate(_cubePrefab, pos, rot);
            cube.transform.localScale = newScale;
            cube.tag = "Cube";

            if (cube.TryGetComponent(out Renderer renderer))
                renderer.material.color = Random.ColorHSV();

            _processor.RegisterNewCube(cube, newChance);
            result.Add(cube);
        }

        return result;
    }
}
