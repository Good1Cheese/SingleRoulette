using Leopotam.EcsLite;
using UnityEngine;
using System.Linq;

public class Enemy : SpawnPointEntity<Enemy>
{
    private readonly Enemy_SO _enemy_SO;

    public Enemy(GameObject gameObject, Transform spawnPoint, Enemy_SO enemy_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(gameObject, spawnPoint, ecsWorld, ecsSystems)
    {
        _enemy_SO = enemy_SO;
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();

        ref Playable playable = ref _world.Add<Playable>(entity);
        playable.Transform = _gameObject.transform;
        playable.SpawnPoint = _spawnPoint;

        ref Explosible explosible = ref _world.Add<Explosible>(entity);
        explosible.Rigidbody = _gameObject.GetComponentInChildren<Rigidbody>();
    }

    protected override void AddSystems()
    {

    }
}