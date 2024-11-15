using UnityEngine;
using Zenject;

public class LocolizeOptionInstaller : BaseOptionInstaller<IntDataTransferObject>
{
    [SerializeField] private LocolizeOptionView _view;

    [Inject] private LocolizeSettingsModel _model;

    protected override string GetKey()
    {
        return SavingConfig.LOCOLIZE_SETTINGS_SAVE_KEY;
    }

    protected override BaseOptionPresenter<IntDataTransferObject> GetPresenter()
    {
        return new LocolizeOptionPresenter(_view, _model);
    }

    protected override IntDataTransferObject GetSelfData()
    {
        return new IntDataTransferObject(_model.CurrentLanguageIndex);
    }

    protected override void SetSelfData(IntDataTransferObject data)
    {
        _model.SetLanguage(data.Data);
    }
}