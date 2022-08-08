using Leopotam.EcsLite;
using System.Linq;

public static class EcsExtensions
{
    public static ref T Get<T>(this EcsWorld world, in int entity) where T : struct
    {
        EcsPool<T> pool = world.GetPool<T>();

        return ref pool.Get(entity);
    }

    public static ref T Add<T>(this EcsWorld world, T existing, in int entity) where T : struct
    {
        ref T result = ref Add<T>(world, entity);

        result = existing;

        return ref result;
    }

    public static ref T Add<T>(this EcsWorld world, in int entity) where T : struct
    {
        EcsPool<T> pool = world.GetPool<T>();
        ref T result = ref pool.Add(entity);

        return ref result;
    }

    public static void Del<T>(this EcsWorld world, in int entity) where T : struct
    {
        EcsPool<T> pool = world.GetPool<T>();

        if (!pool.Has(entity)) { return; }

        pool.Del(entity);
    }

    public static bool ContainsAny<System>(this EcsSystems systems) where System : class
    {
        return systems.GetAllSystems().Any(system => system as System != null);
    }
}