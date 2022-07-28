using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationSystem : IEcsRunSystem
{
    private readonly InputAction _inputAction;
    private Vector2 _input;

    public RotationSystem(InputAction inputAction)
    {
        _inputAction = inputAction;
    }

    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Rotatable>().End();
        var rotatables = world.GetPool<Rotatable>();

        foreach (int entity in filter)
        {
            ref Rotatable rotatable = ref rotatables.Get(entity);

            _input += _inputAction.ReadValue<Vector2>() * Time.deltaTime * rotatable.Multilier;

            rotatable.Head.localRotation = Quaternion.Euler(_input.y, _input.x, 0);
        }
    }
}