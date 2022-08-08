using UnityEngine;

public class EntityInit<Entity, EntitySO> where Entity : GameObjectEntity<Entity> where EntitySO : Entity_SO
{
    private readonly GameObjectEntity<Entity>.Factory _factory;
    private readonly EntitySO _entity_SO;

    public EntityInit(GameObjectEntity<Entity>.Factory factory, EntitySO entity_SO)
    {
        _entity_SO = entity_SO;
        _factory = factory;
    }

    public void Init(Transform spawnPoint)
    {
        GameObject gameObject = Object.Instantiate(_entity_SO.prefab,
                                                   spawnPoint.position,
                                                   spawnPoint.rotation);

        Init(gameObject);
    }

    public void Init(GameObject gameObject)
    {
        Entity entity = _factory.Create(gameObject);

        entity.Init();
    }
}