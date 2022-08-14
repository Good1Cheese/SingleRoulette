using Leopotam.EcsLite;

public class ExplodedPlayableDeleteSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Playable>().Inc<ExplodedMarker>().End();

        foreach (int entity in filter)
        {
            world.DelEntity(entity);
        }
    }
}