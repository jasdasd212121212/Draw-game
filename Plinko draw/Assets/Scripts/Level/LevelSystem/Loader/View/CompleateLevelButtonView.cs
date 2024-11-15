public class CompleateLevelButtonView : LevelButtonBase
{
    protected override void OnClicked()
    {
        Presenter.CompleateAndLoadLevel();
    }
}