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

        EcsFilter filter = world.Filter<GameMarker>().Inc<MoveDoneMarker>().End();

        foreach (int entity in filter)
        {
            world.Del<MoveDoneMarker>(entity);

            SelectRandomPlayer(world);
        }
    }

    private void SelectRandomPlayer(EcsWorld world)
    {
        EcsFilter filter = world.Filter<Playable>().End();

        int entitiesCount = filter.GetEntitiesCount();
        int randomEntityIndex = Random.Range(0, entitiesCount);

        int i = 0;
        foreach (int entity in filter)
        {
            if (i == randomEntityIndex)
            {
                world.Add<MoveMarker>(entity);

                return;
            }

            i++;
        }
    }
}