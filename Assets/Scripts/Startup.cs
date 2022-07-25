using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class Startup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    [Inject]
    public void Construct(EcsWorld ecsWorld, EcsSystems ecsSystems)
    {
        _world = ecsWorld;
        _systems = ecsSystems;
    }

    private void Start()
    {
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _world.Destroy();
        _systems.Destroy();
    }
}