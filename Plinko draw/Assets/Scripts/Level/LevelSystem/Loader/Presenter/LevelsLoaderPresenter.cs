public class LevelsLoaderPresenter
{
    private LevelsLoader _model;
    private LevelProgressModel _progress;

    public LevelsLoaderPresenter(LevelsLoader model, LevelProgressModel progress)
    {
        _model = model;
        _progress = progress;
    }

    public void CompleateAndLoadLevel()
    {
        _progress.CompleateLevel();
        _progress.NextLevel();

        _model.LoadLevel(_progress.CurrentLevelIndex);
    }

    public void RestartLevel()
    {
        _model.LoadLevel(_progress.CurrentLevelIndex);
    }

    public void RestartAndCompleateLevel()
    {
        _progress.CompleateLevel();
        _model.LoadLevel(_progress.CurrentLevelIndex);
    }

    public void ExitToMainMenuAndCompleateLevel()
    {
        _progress.CompleateLevel();
        _model.LoadMainMenu();
    }
}