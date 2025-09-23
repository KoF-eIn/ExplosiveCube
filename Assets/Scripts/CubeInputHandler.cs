using UnityEngine;
using System;

public class CubeInputHandler : MonoBehaviour
{
    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                OnCubeClicked?.Invoke(cube);
            }
        }
    }
}