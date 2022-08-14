using Leopotam.EcsLite;

public class EndMoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter explodedMarkersFilter = world.Filter<ExplodedMarker>().End();

        foreach (int playableEntity in explodedMarkersFilter)
        {
            EcsFilter games = world.Filter<GameMarker>().End();

            foreach (int entity in games)
            {
                world.Add<DoneMoveMarker>(entity);
            }
        }
    }
}