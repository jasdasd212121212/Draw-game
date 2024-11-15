using UnityEngine;
using Zenject;

public class DrawInputInstaller : MonoInstaller
{
    [SerializeField] private GameObject _inputGameObject;

    private void OnValidate()
    {
        if (_inputGameObject != null)
        {
            if (_inputGameObject.GetComponent<IDrawInput>() == null)
            {
                Debug.LogError($"Can`t set gameObject: {_inputGameObject} because this object are not contains any script realises {nameof(IDrawInput)} interface");
                _inputGameObject = null;
            }
        }
    }

    public override void InstallBindings()
    {
        Container.Bind<IDrawInput>().FromInstance(_inputGameObject.GetComponent<IDrawInput>()).AsSingle().Lazy();
    }
}