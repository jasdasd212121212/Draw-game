using Cysharp.Threading.Tasks;

public interface IEnvironmentDataWriteStrategy
{
    UniTask WriteToData(EnvironmentData data);
}