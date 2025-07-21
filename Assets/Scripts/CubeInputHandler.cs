using UnityEngine;
using System;

public class CubeInputHandler : MonoBehaviour
{
    public event Action<GameObject> OnCubeClicked;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Cube"))
            {
                OnCubeClicked?.Invoke(hit.collider.gameObject);
            }
        }
    }
}
