using Leopotam.EcsLite;
using UnityEngine;

public class GameProgress : IEcsPreInitSystem, IEcsRunSystem
{
    public void PreInit(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        SelectRandomPlayer(world);
    }

    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<GameMarker>().Inc<DoneMoveMarker>().End();

        foreach (int entity in filter)
        {
            world.Del<DoneMoveMarker>(entity);

            SelectRandomPlayer(world);
        }
    }

    private void SelectRandomPlayer(EcsWorld world)
    {
        EcsFilter filter = world.Filter<Playable>().End();

        int entitiesCount = filter.GetEntitiesCount();

        if (entitiesCount <= 1) { return; }

        int randomEntityIndex = Random.Range(0, entitiesCount);

        int i = 0;
        foreach (int entity in filter)
        {
            if (i == randomEntityIndex)
            {
                world.Add<MoveMarker>(entity);
                world.Add<OneFrameMoveMarker>(entity);

                return;
            }

            i++;
        }
    }
}