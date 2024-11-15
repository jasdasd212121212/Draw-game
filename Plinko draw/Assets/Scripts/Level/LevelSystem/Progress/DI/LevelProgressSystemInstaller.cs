using Zenject;

public class LevelProgressSystemInstaller : MonoInstaller
{
    [Inject] private LevelSettings _settings;
    [Inject] private ISavingSystem _savingSystem;

    public override void InstallBindings()
    {
        LevelProgressModel progressModel = new LevelProgressModel(_settings);
        new SaverComponent<LevelProgressSaveData>(SavingConfig.LEVEL_PROGRESS_SAVE_KEY, progressModel, _savingSystem);

        Container.Bind<LevelProgressModel>().FromInstance(progressModel).AsSingle().NonLazy();
    }
}