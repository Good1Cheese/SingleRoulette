using UnityEngine;
using Zenject;

public class PlayerInit : EntityInit
{
    [SerializeField] private Transform _spawnPoint;

    private Player.Factory _factory;
    private Player_SO _player_SO;

    [Inject]
    public void Construct(Player_SO player_SO, Player.Factory factory)
    {
        _player_SO = player_SO;
        _factory = factory;
    }

    public override void Init()
    {
        Player player = _player_SO.Spawn(_factory, _spawnPoint);

        player.Init();
    }
}