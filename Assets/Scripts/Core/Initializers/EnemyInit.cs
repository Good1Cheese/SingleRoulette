using UnityEngine;
using Zenject;

public class EnemyInit : EntityInit
{
    [SerializeField] private Transform[] _spawnPoints;

    private Enemy_SO _enemy_SO;
    private Enemy.Factory _factory;

    [Inject]
    public void Construct(Enemy_SO enemy_SO, Enemy.Factory factory)
    {
        _enemy_SO = enemy_SO;
        _factory = factory;
    }

    public override void Init()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Enemy enemy = _enemy_SO.Spawn(_factory, spawnPoint);

            enemy.Init();
        }
    }
}