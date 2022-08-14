using System;
using UnityEngine;

public partial struct Fireable
{
    [Serializable]
    public struct Explosion
    {
        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float explosionRandomRadius;

        public float ExplosionForce => explosionForce;
        public float ExplosionRadius => explosionRadius;
        public float ExplosionRandomRadius => explosionRandomRadius;
    }
}