using Cysharp.Threading.Tasks;

public interface ISavingSystem
{
    UniTask Save<T>(string key, T data);
    UniTask<T> Load<T>(string key);
    UniTask<bool> HasKey(string key);
}