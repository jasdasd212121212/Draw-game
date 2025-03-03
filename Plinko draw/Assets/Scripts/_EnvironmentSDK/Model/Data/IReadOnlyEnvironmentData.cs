using Cysharp.Threading.Tasks;

public interface IReadOnlyEnvironmentData
{
    UniTask<T> ReadSegment<T>() where T : EnvironmentDataSegment;
}