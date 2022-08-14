using Leopotam.EcsLite;
using UnityEngine;

public class ExplodeSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter explosibleFilter = world.Filter<Explosible>().Inc<ExplosionMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().Inc<Fireable.Explosion>().End();

        foreach (int explosibleEntity in explosibleFilter)
        {
            ref Explosible explosible = ref world.Get<Explosible>(explosibleEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);
                ref Fireable.Explosion fireableExplosion = ref world.Get<Fireable.Explosion>(fireableEntity);

                Explode(explosible, fireableExplosion);

                world.Add<ExplodedMarker>(explosibleEntity, fireable.DelayBeforeNextMoveMilliseconds);
            }
        }
    }

    private void Explode(in Explosible explosible, in Fireable.Explosion fireableExplosion)
    {
        explosible.Rigidbody.useGravity = true;

        Vector3 randomPosition = GetRandomExplosionPosition(explosible.Rigidbody.transform.position, fireableExplosion);

        explosible.Rigidbody.AddExplosionForce(fireableExplosion.ExplosionForce,
                                               randomPosition,
                                               fireableExplosion.ExplosionRadius,
                                               1,
                                               ForceMode.Impulse);
    }

    private Vector3 GetRandomExplosionPosition(in Vector3 startPosition, in Fireable.Explosion fireableExplosion)
    {
        return startPosition + (Random.insideUnitSphere * fireableExplosion.ExplosionRandomRadius);
    }
}