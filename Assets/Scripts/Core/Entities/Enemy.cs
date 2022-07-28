using Leopotam.EcsLite;
using UnityEngine;

public class Enemy : Entity<Enemy>
{
    private readonly Enemy_SO _enemy_SO;

    public Enemy(GameObject gameObject, Enemy_SO enemy_SO, EcsWorld ecsWorld, EcsSystems ecsSystems) 
        : base(gameObject, ecsWorld, ecsSystems)
    {
        _enemy_SO = enemy_SO;
    }

    protected override void AddComponents()
    {
        
    }

    protected override void AddSystems()
    {
        
    }
}