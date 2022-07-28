using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public abstract class Entity<T>
{
    protected EcsWorld _world;
    protected EcsSystems _systems;
    protected GameObject _gameObject;

    protected Entity(GameObject gameObject, EcsWorld ecsWorld, EcsSystems ecsSystems)
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