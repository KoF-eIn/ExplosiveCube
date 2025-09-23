using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] public float SplitChance { get; private set; } = 1f;

    [SerializeField] public Rigidbody Rigidbody { get; private set; }

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
