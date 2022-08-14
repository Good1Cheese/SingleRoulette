using Leopotam.EcsLite;
using System.Threading.Tasks;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
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

                MoveWithDelay(world, playable, fireable, fireableEntity);
            }
        }
    }

    private async void MoveWithDelay(EcsWorld world, Playable playable, Fireable fireable, int entity)
    {
        Vector3 targetPosition = GetTargetPosition(playable, fireable);
        Vector3 currentPositon = fireable.Transform.localPosition;

        while (targetPosition != currentPositon)
        {
            currentPositon = Vector3.Lerp(currentPositon, targetPosition, fireable.MoveSmoothTime * Time.deltaTime);
            fireable.Transform.localPosition = currentPositon;

            await Task.Yield();
        }

        world.Add<MovedMarker>(entity);
    }

    private Vector3 GetTargetPosition(in Playable playable, in Fireable fireable)
    {
        var c = playable.SpawnPoint.position;
        c /= fireable.PositionMultiplier;
        c.y = fireable.YPosition;

        return c;
    }
}