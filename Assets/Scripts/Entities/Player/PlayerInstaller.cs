using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player_SO _player_SO;

    public override void InstallBindings()
    {
        Container.BindInstance(_player_SO)
            .AsSingle();

        Container.BindFactory<GameObject,Transform, Player, Player.Factory>()
            .AsSingle();
    }
}