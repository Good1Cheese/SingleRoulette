using Leopotam.EcsLite;
using UnityEngine;
using System.Linq;

public class Enemy : GameObjectEntity<Enemy>
{
    private readonly Enemy_SO _enemy_SO;

    public Enemy(GameObject gameObject, Enemy_SO enemy_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(gameObject, ecsWorld, ecsSystems)
    {
        _enemy_SO = enemy_SO;
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();

        ref Playable playable = ref _world.Add<Playable>(entity);
        playable.Transform = _gameObject.transform;
        playable.Rigidbody = _gameObject.GetComponentInChildren<Rigidbody>();
    }

    protected override void AddSystems()
    {

    }
}