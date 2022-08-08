using Leopotam.EcsLite;
using System.Threading.Tasks;
using UnityEngine;

public class RotateSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<MoveMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);
                Quaternion targetRotation = GetTargetRotation(fireable, playable);

                Rotate(fireable, targetRotation, world, fireableEntity);
            }
        }
    }

    private Quaternion GetTargetRotation(in Fireable fireable, in Playable playable)
    {
        Vector3 directionToPlayable = playable.Transform.position - fireable.Transform.position;

        return Quaternion.LookRotation(directionToPlayable);
    }

    private async void Rotate(Fireable fireable, Quaternion targetRotation, EcsWorld world, int entity)
    {
        float time = 0;

        while (time < fireable.RotateTime)
        {
            time += Time.deltaTime;

            fireable.Transform.rotation = Quaternion.Lerp(fireable.Transform.rotation,
                                                          targetRotation,
                                                          fireable.RotateSmoothTime * Time.deltaTime);

            await Task.Yield();
        }

        world.Add<RotatedMarker>(entity);
    }
}