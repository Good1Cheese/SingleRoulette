using Leopotam.EcsLite;
using System.Threading.Tasks;

public class SpinSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter playableFilter = world.Filter<Playable>().Inc<MoveMarker>().End();
        EcsFilter fireableFilter = world.Filter<Fireable>().Inc<Fireable.Sounds>().Inc<RotatedMarker>().Inc<MovedMarker>().End();

        foreach (int playableEntity in playableFilter)
        {
            ref Playable playable = ref world.Get<Playable>(playableEntity);

            foreach (int fireableEntity in fireableFilter)
            {
                ref Fireable fireable = ref world.Get<Fireable>(fireableEntity);
                ref Fireable.Sounds fireableSounds = ref world.Get<Fireable.Sounds>(fireableEntity);

                fireableSounds.AudioSource.PlayOneShot(fireableSounds.SpinSound);

                world.Add<SpunMarker>(fireableEntity);
            }
        }
    }
}