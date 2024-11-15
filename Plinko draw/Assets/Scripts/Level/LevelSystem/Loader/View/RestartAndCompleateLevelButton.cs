public class RestartAndCompleateLevelButton : LevelButtonBase
{
    protected override void OnClicked()
    {
        Presenter.RestartAndCompleateLevel();
    }
}