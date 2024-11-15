using UnityEngine;
using Zenject;

public class AdsInstaller : MonoInstaller
{
    [SerializeField] private GameObject _adsFacadeGameObject;

    private void OnValidate()
    {
        if (_adsFacadeGameObject != null)
        {
            if (_adsFacadeGameObject.GetComponent<IAdsFacade>() == null)
            {
                Debug.LogError($"Critical error -> can`t set a gameObject: {_adsFacadeGameObject} without any script realising {nameof(IAdsFacade)}");
                _adsFacadeGameObject = null;
            }
        }
    }

    public override void InstallBindings()
    {
        if (_adsFacadeGameObject != null)
        {
            Container.Bind<IAdsFacade>().FromInstance(_adsFacadeGameObject.GetComponent<IAdsFacade>()).AsSingle().NonLazy();
        }
    }
}