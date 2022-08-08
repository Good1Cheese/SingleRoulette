using Leopotam.EcsLite;
using UnityEngine;

public class SurviveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<SurviveMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);

                fireable.Rigidbody.useGravity = true;
                fireable.AudioSource.PlayOneShot(fireable.ClickSound);
                world.Del<SurviveMarker>(playableEntity);
            }
        }
    }
}