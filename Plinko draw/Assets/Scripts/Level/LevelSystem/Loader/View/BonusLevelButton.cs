public class BonusLevelButton : LevelButtonBase
{
    protected override void OnClicked()
    {
        Model.LoadBonusScene();
    }
}