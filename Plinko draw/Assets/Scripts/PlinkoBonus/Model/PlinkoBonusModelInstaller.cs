using UnityEngine;
using Zenject;

public class PlinkoBonusModelInstaller : MonoInstaller
{
    [SerializeField][Min(0.01f)] private float _coeficient;

    public override void InstallBindings()
    {
        Container.Bind<PlinkoBonusModel>().FromInstance(new PlinkoBonusModel(_coeficient)).AsSingle().Lazy();
    }
}