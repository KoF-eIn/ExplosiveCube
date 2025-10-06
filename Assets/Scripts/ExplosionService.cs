using UnityEngine;
using System.Collections.Generic;

public class ExplosionService : MonoBehaviour
{
    [SerializeField] private float _baseForce = 300f;
    [SerializeField] private float _baseRadius = 2f;

    public void ExplodeLocal(List<Cube> cubes, Vector3 origin)
    {
        foreach (var cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_baseForce, origin, _baseRadius);
        }
    }

    public void ExplodeArea(Cube source)
    {
        float scaleFactor = 1f / source.transform.localScale.magnitude;
        float explosionForce = _baseForce * scaleFactor;
        float explosionRadius = _baseRadius * scaleFactor;

        Collider[] colliders = Physics.OverlapSphere(source.transform.position, explosionRadius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Cube cube) && cube != source)
            {
                Rigidbody rb = cube.Rigidbody;

                if (rb == null) continue;

                float distance = Vector3.Distance(source.transform.position, cube.transform.position);
                float forceMultiplier = 1f - (distance / explosionRadius);

                forceMultiplier = Mathf.Clamp01(forceMultiplier);

                rb.AddExplosionForce(explosionForce * forceMultiplier, source.transform.position, explosionRadius);
            }
        }
    }
}
