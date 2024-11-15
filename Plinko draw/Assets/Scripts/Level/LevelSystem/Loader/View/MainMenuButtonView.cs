public class MainMenuButtonView : LevelButtonBase
{
    protected override void OnClicked()
    {
        Model.LoadMainMenu();
    }
}