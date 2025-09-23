using UnityEngine;
using System.Collections.Generic;

public class ExplosionService : MonoBehaviour
{
    [SerializeField] private float force = 300f;
    [SerializeField] private float radius = 2f;

    public void Explode(List<Cube> cubes, Vector3 origin)
    {
        foreach (var cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(force, origin, radius);
        }
    }
}
