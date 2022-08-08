using Leopotam.EcsLite;
using UnityEngine;
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

public abstract class GameObjectEntity<T>
{
    protected EcsWorld _world;
    protected EcsSystems _systems;
    protected GameObject _gameObject;

    protected GameObjectEntity(GameObject gameObject, EcsWorld ecsWorld, EcsSystems ecsSystems)
    {
        _world = ecsWorld;
        _systems = ecsSystems;
        _gameObject = gameObject;
    }

    public void Init()
    {
        AddComponents();
        AddSystems();
    }

    protected abstract void AddComponents();
    protected abstract void AddSystems();

    public class Factory : PlaceholderFactory<GameObject, T> { }
}