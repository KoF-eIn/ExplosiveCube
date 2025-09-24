using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int _leftMouseButton = 0;

    public bool IsLeftMouseButtonDown()
    {
        return Input.GetMouseButtonDown(_leftMouseButton);
    }
}
