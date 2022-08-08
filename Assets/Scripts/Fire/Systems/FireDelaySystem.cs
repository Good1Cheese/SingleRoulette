using Leopotam.EcsLite;
using System.Threading.Tasks;
using UnityEngine;

public class FireDelaySystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<MoveMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().End();

        foreach (int playableEntity in playableFilter)
        {
            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);

                FireWithDelay(world, fireable.DelayBeforeFireMilliseconds, playableEntity);
            }
        }
    }

    private async void FireWithDelay(EcsWorld world, int delay, int entity)
    {
        await Task.Delay(delay);

        world.Add<FireDelayMarker>(entity);
    }
}