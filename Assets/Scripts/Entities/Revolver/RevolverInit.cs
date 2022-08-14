using UnityEngine;
using Zenject;

public class RevolverInit : MonoBehaviour, IInitiatable
{
    [SerializeField] private GameObject _gameObject;

    private ExistingEntityInit<Revolver> _revolverInit;

    [Inject]
    public void Construct(Revolver.Factory revolverFactory)
    {
        _revolverInit = new(revolverFactory);
    }

    public void Init()
    {
        _revolverInit.Init(_gameObject);
    }
}