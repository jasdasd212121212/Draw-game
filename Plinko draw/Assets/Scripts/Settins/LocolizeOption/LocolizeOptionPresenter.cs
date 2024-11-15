public class LocolizeOptionPresenter : BaseOptionPresenter<IntDataTransferObject>
{
    private LocolizeSettingsModel _settingsModel;

    public LocolizeOptionPresenter(BaseOptionView<IntDataTransferObject> view, LocolizeSettingsModel settingsModel) : base(view)
    {
        _settingsModel = settingsModel;
    }

    protected override void Apply(IntDataTransferObject data)
    {
        _settingsModel.SetLanguage(data.Data);
    }

    protected override IntDataTransferObject GetDefaultData()
    {
        return View.State;
    }
}