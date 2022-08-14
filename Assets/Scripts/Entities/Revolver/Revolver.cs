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

        ref Fireable playable = ref _world.Add(_revolver_SO.fireable, entity);
        playable.Transform = _gameObject.transform;

        ref Explosible explosible = ref _world.Add<Explosible>(entity);
        explosible.Rigidbody = _gameObject.GetComponent<Rigidbody>();

        ref Fireable.Sounds fireableSounds = ref _world.Add(_revolver_SO.fireableSounds, entity);
        fireableSounds.AudioSource = _gameObject.GetComponent<AudioSource>();

        _world.Add(_revolver_SO.fireableExplosion, entity);
    }

    protected override void AddSystems()
    {
        _systems.Add(new RotateSystem());
        _systems.Add(new MoveSystem());
        _systems.Add(new SpinSystem());
        _systems.Add(new FireSystem());
        _systems.Add(new ExplodeSystem());
        _systems.Add(new EndMoveSystem());
        _systems.Add(new ExplodedPlayableDeleteSystem());
        _systems.Add(new MarkerDeleteSystem<OneFrameMoveMarker>());
        _systems.Add(new MarkerDeleteSystem<ExplodedMarker>());
        _systems.Add(new MarkerDeleteSystem<ExplosionMarker>());
    }
}