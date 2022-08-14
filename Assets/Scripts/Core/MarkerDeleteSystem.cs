using Leopotam.EcsLite;

public class MarkerDeleteSystem<Marker> : IEcsRunSystem where Marker: struct
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Marker>().End();

        foreach (int entity in filter)
        {
            world.Del<Marker>(entity);
        }
    }
}