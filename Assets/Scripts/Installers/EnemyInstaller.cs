using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private Enemy_SO _enemy_SO;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemy_SO)
            .AsSingle();

        Container.BindFactory<GameObject, Enemy, Enemy.Factory>()
            .AsSingle();
    }
}