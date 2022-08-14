using Leopotam.EcsLite;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        EcsWorld world = new();
        EcsSystems systems = new(world);

        Container.BindInstance(world)
            .AsSingle();

        Container.BindInstance(systems)
            .AsSingle();

        Container.BindFactory<Game, Game.Factory>()
            .AsSingle();
    }
}