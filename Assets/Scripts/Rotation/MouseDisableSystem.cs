using Leopotam.EcsLite;
using UnityEngine;

public class MouseDisableSystem : IEcsInitSystem
{
    public void Init(IEcsSystems systems)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}