using Leopotam.EcsLite;
using UnityEngine;

public class Player : SpawnPointEntity<Player>
{
    private readonly PlayerControls _controls;
    private readonly Player_SO _playerSO;

    public Player(GameObject gameObject, Transform spawnPoint, Player_SO playerSO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(gameObject, spawnPoint, ecsWorld, ecsSystems)
    {
        _playerSO = playerSO;

        _controls = new();
        _controls.Enable();
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();

        ref Rotatable rotatable = ref _world.Add(_playerSO.rotatable, entity);
        rotatable.InputAction = _controls.Main.Rotation;
        rotatable.Head = _gameObject.GetComponentInChildren<Camera>().transform;

        ref Playable playable = ref _world.Add<Playable>(entity);
        playable.Transform = _gameObject.transform;
        playable.SpawnPoint = _spawnPoint;

        ref Explosible explosible = ref _world.Add<Explosible>(entity);
        explosible.Rigidbody = _gameObject.GetComponentInChildren<Rigidbody>();
    }

    protected override void AddSystems()
    {
        _systems.Add(new MouseDisableSystem());
        _systems.Add(new RotationSystem());
    }
}