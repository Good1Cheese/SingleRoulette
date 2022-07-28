using Leopotam.EcsLite;

public static class EcsExtensions
{
    public static ref T Add<T>(this EcsWorld world, T existing, in int entity) where T : struct
    {
        EcsPool<T> componentPool = world.GetPool<T>();
        ref T result = ref componentPool.Add(entity);

        result = existing;

        return ref result;
    }
}