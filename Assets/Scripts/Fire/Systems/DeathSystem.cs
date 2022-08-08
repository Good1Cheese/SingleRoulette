using Leopotam.EcsLite;
using UnityEngine;

public class DeathSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<DeathMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);
                ref FireableExplosion fireableExplosion = ref world.Get<FireableExplosion>(fireableEntity);

                Explode(playable, fireableExplosion);
                fireable.AudioSource.PlayOneShot(fireable.FireSound);

                world.Del<DeathMarker>(playableEntity);

                world.DelEntity(playableEntity);
            }
        }
    }

    private void Explode(in Playable playable, in FireableExplosion fireableExplosion)
    {
        playable.Rigidbody.useGravity = true;

        Vector3 randomPosition = GetRandomExplosionPosition(playable.Transform.position, fireableExplosion);

        playable.Rigidbody.AddExplosionForce(fireableExplosion.ExplosionForce, randomPosition, fireableExplosion.ExplosionRadius, 1, ForceMode.Impulse);
    }

    private Vector3 GetRandomExplosionPosition(in Vector3 startPosition, in FireableExplosion fireableExplosion)
    {
        return startPosition + (Random.insideUnitSphere * fireableExplosion.ExplosionRandomRadius);
    }
}
