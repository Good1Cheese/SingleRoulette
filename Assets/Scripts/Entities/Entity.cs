using Leopotam.EcsLite;
using Zenject;

public abstract class Entity<T>
{
    protected EcsWorld _world;
    protected EcsSystems _systems;

    protected Entity(EcsWorld ecsWorld, EcsSystems ecsSystems)
    {
        _world = ecsWorld;
        _systems = ecsSystems;
    }

    public void Init()
    {
        AddComponents();
        AddSystems();
    }

    protected abstract void AddComponents();
    protected abstract void AddSystems();

    public class Factory : PlaceholderFactory<T> { }
}