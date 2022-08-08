using System;
using UnityEngine;

[Serializable]
public struct FireableExplosion
{
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionRandomRadius;

    public float ExplosionForce => explosionForce;
    public float ExplosionRadius => explosionRadius;
    public float ExplosionRandomRadius => explosionRandomRadius;
}