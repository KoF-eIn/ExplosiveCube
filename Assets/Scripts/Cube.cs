using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

    [field: SerializeField] public float SplitChance { get; private set; } = 1f;

    private void Awake()
    {
        if (Rigidbody == null)
            Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetSplitChance(float chance)
    {
        SplitChance = chance;
    }
}
