using Leopotam.EcsLite;

public class MoveMarkerDeleteSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter moveMarkersFilter = world.Filter<Playable>().Inc<MoveMarker>().End();

        foreach (int entity in moveMarkersFilter)
        {
            world.Del<MoveMarker>(entity);
        }
    }
}