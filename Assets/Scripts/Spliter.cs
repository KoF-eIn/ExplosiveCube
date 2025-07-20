using UnityEngine;
using System;

public class Spliter : MonoBehaviour
{
    private GameObject _cubePrefab;

    private float _splitChance;

    public static event Action<Spliter> OnRequestSpawn;

    private void OnMouseDown()
    {
        if (UnityEngine.Random.value <= _splitChance)
        {
            SplitCube();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SplitCube()
    {
        const int minCount = 2;
        const int maxCount = 6;

        const float scaleFactor = 0.5f;
        const float explosionForce = 300f;
        const float explosionRadius = 2f;

        int count = UnityEngine.Random.Range(minCount, maxCount + 1);

        Vector3 spawnPosition = transform.position;
        Vector3 newScale = transform.localScale * scaleFactor;

        GameObject[] spawnedCubes = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = UnityEngine.Random.onUnitSphere * 0.5f;
            Quaternion rotation = UnityEngine.Random.rotation;

            if (OnRequestSpawn != null)
            {
                OnRequestSpawn(this);
            }

            GameObject newCube = Instantiate(_cubePrefab, spawnPosition + offset, rotation);

            newCube.transform.localScale = newScale;

            ApplyRandomColor(newCube);
            InitializeNewCube(newCube);

            spawnedCubes[i] = newCube;
        }

        ApplyExplosionForce(spawnedCubes, spawnPosition, explosionForce, explosionRadius);

        Destroy(gameObject);
    }

    private void ApplyRandomColor(GameObject cube)
    {
        if (cube.TryGetComponent<Renderer>(out Renderer renderer))
        {
            renderer.material.color = UnityEngine.Random.ColorHSV();
        }
    }

    private void InitializeNewCube(GameObject cube)
    {
        if (cube.TryGetComponent<Spliter>(out Spliter spliter))
        {
            spliter.SetParameters(_cubePrefab, _splitChance * 0.5f);
        }
    }

    private void ApplyExplosionForce(GameObject[] cubes, Vector3 origin, float force, float radius)
    {
        foreach (GameObject cube in cubes)
        {
            if (cube.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddExplosionForce(force, origin, radius);
            }
        }
    }

    public void SetParameters(GameObject prefab, float chance)
    {
        _cubePrefab = prefab;
        _splitChance = chance;
    }
}
