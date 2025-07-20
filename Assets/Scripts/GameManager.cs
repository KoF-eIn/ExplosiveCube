using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private void OnEnable()
    {
        Spliter.OnRequestSpawn += HandleCubeSpawn;
    }

    private void OnDisable()
    {
        Spliter.OnRequestSpawn -= HandleCubeSpawn;
    }

    private void Start()
    {
        SpawnInitialCube();
    }

    private void SpawnInitialCube()
    {
        GameObject cube = Instantiate(_cubePrefab, Vector3.zero, Quaternion.identity);

        cube.transform.localScale = Vector3.one;

        if (cube.TryGetComponent<Spliter>(out Spliter spliter))
        {
            spliter.SetParameters(_cubePrefab, 1f);
        }

        if (cube.TryGetComponent<Renderer>(out Renderer renderer))
        {
            renderer.material.color = Random.ColorHSV();
        }
    }

    private void HandleCubeSpawn(Spliter caller)
    {
        caller.SetParameters(_cubePrefab, 1f);
    }
}
