using UnityEngine;
using System;

public class CubeInputHandler : MonoBehaviour
{
    public event Action<Cube> CubeClicked;

    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        if (!_inputReader.IsLeftMouseButtonDown()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeClicked?.Invoke(cube);
            }
        }
    }
}
