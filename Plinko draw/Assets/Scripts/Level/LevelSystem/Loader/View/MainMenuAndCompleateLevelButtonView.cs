public class MainMenuAndCompleateLevelButtonView : LevelButtonBase
{
    protected override void OnClicked()
    {
        Presenter.ExitToMainMenuAndCompleateLevel();
    }
}