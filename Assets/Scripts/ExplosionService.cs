using UnityEngine;
using System.Collections.Generic;

public class ExplosionService : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float radius;

    public void Explode(List<GameObject> cubes, Vector3 origin)
    {
        foreach (var cube in cubes)
        {
            if (cube.TryGetComponent(out Rigidbody rb))
            {
                rb.AddExplosionForce(force, origin, radius);
            }
        }
    }
}
