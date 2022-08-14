using Leopotam.EcsLite;
using System.Threading.Tasks;
using UnityEngine;

public class RotateSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<OneFrameMoveMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);

                RotateWithDelay(world, playable, fireable, fireableEntity);
            }
        }
    }

    private async void RotateWithDelay(EcsWorld world, Playable playable, Fireable fireable, int entity)
    {
        Quaternion targetRotation = playable.SpawnPoint.parent.localRotation;
        Quaternion currentRotation = fireable.Transform.localRotation;

        while (!Mathf.Approximately(Mathf.Abs(Quaternion.Dot(targetRotation, currentRotation)), 1))
        {
            currentRotation = Quaternion.Lerp(currentRotation, targetRotation, fireable.RotateSmoothTime * Time.deltaTime);
            fireable.Transform.localRotation = currentRotation;

            await Task.Yield();
        }

        world.Add<RotatedMarker>(entity);
    }
}