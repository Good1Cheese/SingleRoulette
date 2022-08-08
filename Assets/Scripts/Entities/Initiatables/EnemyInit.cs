using UnityEngine;
using Zenject;

public class EnemyInit : MonoBehaviour, IInitiatable
{
    [SerializeField] private Transform[] _spawnPoints;

    private EntityInit<Enemy, Enemy_SO> _enemyInit;

    [Inject]
    public void Construct(Enemy.Factory enemyFactory, Enemy_SO enemy_SO)
    {
        _enemyInit = new(enemyFactory, enemy_SO);
    }

    public void Init()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            _enemyInit.Init(spawnPoint);
        }
    }
}