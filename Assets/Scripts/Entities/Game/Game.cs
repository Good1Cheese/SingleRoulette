using Leopotam.EcsLite;
using UnityEngine;

public class Game : Entity<Game>
{
    public Game(EcsWorld ecsWorld, EcsSystems ecsSystems) 
        : base(ecsWorld, ecsSystems)
    {
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();

        _world.Add<GameMarker>(entity);
    }

    protected override void AddSystems()
    {
        _systems.Add(new GameProgress());
    }
}