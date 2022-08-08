using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class Startup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;
    private Game _game;

    [Inject]
    public void Construct(EcsWorld ecsWorld, EcsSystems ecsSystems, Game.Factory gameFactory) 
    {
        _world = ecsWorld;
        _systems = ecsSystems;
        _game = gameFactory.Create();
    }

    private void Awake()
    {
        var initiatables = GetComponents<IInitiatable>();

        foreach (var initiatable in initiatables)
        {
            initiatable.Init();
        }
    }

    private void Start()
    {
        _game.Init();
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