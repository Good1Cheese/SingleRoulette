using UnityEngine;
using Zenject;

public static class EntityExtensions
{
    public static Entity Spawn<Entity, EntitySO>(this EntitySO entity_SO, Entity<Entity>.Factory factory, Transform spawnPoint) where Entity : Entity<Entity> where EntitySO : Entity_SO
    {
        GameObject player = Object.Instantiate(entity_SO.prefab,
                                               spawnPoint.position,
                                               spawnPoint.rotation);

        return factory.Create(player);
    }
}