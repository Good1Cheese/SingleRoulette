using Leopotam.EcsLite;
using UnityEngine;

public class Revolver : GameObjectEntity<Revolver>
{
    private readonly Revolver_SO _revolver_SO;

    public Revolver(GameObject gameObject, Revolver_SO revolver_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(gameObject, ecsWorld, ecsSystems)
    {
        _revolver_SO = revolver_SO;
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();

        ref Fireable fireable = ref _world.Add(_revolver_SO.fireable, entity);
        fireable.AudioSource = _gameObject.GetComponent<AudioSource>();
        fireable.Transform = _gameObject.transform;
        fireable.Rigidbody = _gameObject.GetComponent<Rigidbody>();

        _world.Add(_revolver_SO.fireableExplosion, entity);
    }

    protected override void AddSystems()
    {
        _systems.Add(new RotateSystem());
        _systems.Add(new FireDelaySystem());
        _systems.Add(new FireSystem());
        _systems.Add(new DeathSystem());
        _systems.Add(new SurviveSystem());
        _systems.Add(new MoveMarkerDeleteSystem());
    }
}