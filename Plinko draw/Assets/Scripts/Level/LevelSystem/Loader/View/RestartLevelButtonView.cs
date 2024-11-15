public class RestartLevelButtonView : LevelButtonBase
{
    protected override void OnClicked()
    {
        Presenter.RestartLevel();
    }
}