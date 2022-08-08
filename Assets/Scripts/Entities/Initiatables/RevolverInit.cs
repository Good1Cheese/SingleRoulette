using UnityEngine;
using Zenject;

public class RevolverInit : MonoBehaviour, IInitiatable
{
    [SerializeField] private GameObject _gameObject;

    private EntityInit<Revolver, Revolver_SO> _revolverInit;

    [Inject]
    public void Construct(Revolver.Factory revolverFactory, Revolver_SO revolver_SO)
    {
        _revolverInit = new(revolverFactory, revolver_SO);
    }

    public void Init()
    {
        _revolverInit.Init(_gameObject);
    }
}