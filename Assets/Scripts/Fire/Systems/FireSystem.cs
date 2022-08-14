using Leopotam.EcsLite;
using System.Threading.Tasks;
using UnityEngine;

public class FireSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<MoveMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().Inc<Fireable.Sounds>().Inc<RotatedMarker>().Inc<MovedMarker>().Inc<SpunMarker>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);
                ref Fireable.Sounds fireableSounds = ref world.Get<Fireable.Sounds>(fireableEntity);

                world.Del<MoveMarker>(playableEntity);
                world.Del<MovedMarker>(fireableEntity);
                world.Del<RotatedMarker>(fireableEntity);
                world.Del<SpunMarker>(fireableEntity);

                Fire(world, fireable, fireableSounds, playableEntity, fireableEntity);
            }
        }
    }

    private async void Fire(EcsWorld world, Fireable fireable, Fireable.Sounds fireableSounds, int playableEntity, int fireableEntity)
    {
        await Task.Delay(fireable.DelayBeforeFireMilliseconds);

        int deathChance = Random.Range(1, 101);

        if (fireable.DeadСhance >= deathChance)
        {
            fireableSounds.AudioSource.PlayOneShot(fireableSounds.FireSound);
            world.Add<ExplosionMarker>(playableEntity);

            return;
        }

        fireableSounds.AudioSource.PlayOneShot(fireableSounds.ClickSound);
        world.Add<ExplosionMarker>(fireableEntity);
    }
}