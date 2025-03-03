using Cysharp.Threading.Tasks;

public class EnvironmentFacade
{
    private IEnvironmentDataWriteStrategy _strategy;
    private EnvironmentData _environmentData;

    public IReadOnlyEnvironmentData Data => _environmentData;

    public EnvironmentFacade(IEnvironmentDataWriteStrategy strategy)
    {
        _environmentData = new();
        _strategy = strategy;

        Initialize().Forget();
    }

    private async UniTask Initialize()
    {
        await _strategy.WriteToData(_environmentData);
        _environmentData.EndWrite();
    }
}