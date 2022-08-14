using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public abstract class GameObjectEntity<T> : Entity<T>
{
    protected GameObject _gameObject;

    protected GameObjectEntity(GameObject gameObject, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(ecsWorld, ecsSystems)
    {
        _gameObject = gameObject;
    }


    public new class Factory : PlaceholderFactory<GameObject, T> { }
}