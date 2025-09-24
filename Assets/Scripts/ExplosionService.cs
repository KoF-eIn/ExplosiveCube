using UnityEngine;
using System.Collections.Generic;

public class ExplosionService : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 2f;

    public void Explode(List<Cube> cubes, Vector3 origin)
    {
        foreach (var cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, origin, _explosionRadius);
        }
    }
}
