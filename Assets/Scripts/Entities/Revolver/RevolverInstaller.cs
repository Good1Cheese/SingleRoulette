using UnityEngine;
using Zenject;

public class RevolverInstaller : MonoInstaller
{
    [SerializeField] private Revolver_SO _revolver_SO;

    public override void InstallBindings()
    {
        Container.BindInstance(_revolver_SO)
            .AsSingle();

        Container.BindFactory<GameObject, Revolver, Revolver.Factory>()
            .AsSingle();
    }
}