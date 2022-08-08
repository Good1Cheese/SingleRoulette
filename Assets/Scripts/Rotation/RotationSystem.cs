using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationSystem : IEcsRunSystem
{
    private Vector2 _input;

    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Rotatable>().End();
        var rotatables = world.GetPool<Rotatable>();

        foreach (int entity in filter)
        {
            ref Rotatable rotatable = ref rotatables.Get(entity);

            _input += rotatable.InputAction.ReadValue<Vector2>() * Time.deltaTime * rotatable.Multilier;

            rotatable.Head.localRotation = Quaternion.Euler(_input.y, _input.x, 0);
        }
    }
}