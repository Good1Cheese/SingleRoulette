using UnityEngine;

public class SpawnableEntityInit<Entity, EntitySO> where Entity : SpawnPointEntity<Entity> where EntitySO : SpawnableEntity_SO
{
    private readonly SpawnPointEntity<Entity>.Factory _factory;
    private readonly EntitySO _entity_SO;

    public SpawnableEntityInit(SpawnPointEntity<Entity>.Factory factory, EntitySO entity_SO)
    {
        _entity_SO = entity_SO;
        _factory = factory;
    }

    public void Init(Transform spawnPoint)
    {
        GameObject gameObject = Object.Instantiate(_entity_SO.prefab,
                                                   spawnPoint.position,
                                                   spawnPoint.rotation);

        Entity entity = _factory.Create(gameObject, spawnPoint);

        entity.Init();
    }
}