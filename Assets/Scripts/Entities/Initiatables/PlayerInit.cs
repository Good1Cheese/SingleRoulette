using UnityEngine;
using Zenject;

public class PlayerInit : MonoBehaviour, IInitiatable
{
    [SerializeField] private Transform _spawnPoint;

    private EntityInit<Player, Player_SO> _playerInit;

    [Inject]
    public void Construct(Player.Factory playerFactory, Player_SO player_SO)
    {
        _playerInit = new(playerFactory, player_SO);
    }

    public void Init()
    {
        _playerInit.Init(_spawnPoint);
    }
}