using UnityEngine;

public class ExistingEntityInit<Entity> where Entity : GameObjectEntity<Entity>
{
    private readonly GameObjectEntity<Entity>.Factory _factory;

    public ExistingEntityInit(GameObjectEntity<Entity>.Factory factory)
    {
        _factory = factory;
    }

    public void Init(GameObject gameObject)
    {
        Entity entity = _factory.Create(gameObject);

        entity.Init();
    }
}