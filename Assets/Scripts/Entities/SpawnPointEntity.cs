using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public abstract class SpawnPointEntity<T> : GameObjectEntity<T>
{
    protected Transform _spawnPoint;

    protected SpawnPointEntity(GameObject gameObject, Transform transform, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(gameObject, ecsWorld, ecsSystems)
    {
        _gameObject = gameObject;
        _spawnPoint = transform;
    }


    public new class Factory : PlaceholderFactory<GameObject, Transform, T> { }
}
