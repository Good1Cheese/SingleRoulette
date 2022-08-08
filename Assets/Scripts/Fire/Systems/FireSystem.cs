using Leopotam.EcsLite;
using UnityEngine;

public class FireSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<FireDelayMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().Inc<RotatedMarker>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);

                Fire(world, fireable, playableEntity);
                AddMoveDoneMarker(world);

                world.Del<FireDelayMarker>(playableEntity);
                world.Del<RotatedMarker>(fireableEntity);
            }
        }
    }

    private void Fire(EcsWorld world, in Fireable fireable, in int playableEntity)
    {
        int deathChance = Random.Range(1, 101);

        if (fireable.DeadСhance <= deathChance)
        {
            world.Add<DeathMarker>(playableEntity);
            return;
        }

        world.Add<SurviveMarker>(playableEntity);
    }

    private void AddMoveDoneMarker(EcsWorld world)
    {
        EcsFilter games = world.Filter<GameMarker>().End();

        foreach (int entity in games)
        {
            world.Add<MoveDoneMarker>(entity);
        }
    }
}
