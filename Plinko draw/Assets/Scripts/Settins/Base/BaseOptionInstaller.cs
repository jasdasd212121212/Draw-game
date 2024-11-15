using System;
using Zenject;

public abstract class BaseOptionInstaller<TDataType> : MonoInstaller
{
    [Inject] private ISavingSystem _savingSystem;

    public override void InstallBindings()
    {
        new SaverComponent<TDataType>(GetKey(), GetPresenter(), _savingSystem);
    }

    public TDataType GetData()
    {
        return GetSelfData();
    }

    public void SetData(TDataType data)
    {
        SetSelfData(data);
    }

    protected abstract BaseOptionPresenter<TDataType> GetPresenter();
    protected abstract string GetKey();

    protected abstract TDataType GetSelfData();
    protected abstract void SetSelfData(TDataType data);
}