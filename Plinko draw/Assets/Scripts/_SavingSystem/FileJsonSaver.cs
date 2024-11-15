using Cysharp.Threading.Tasks;
using System.IO;
using UnityEngine;

public class FileJsonSaver : ISavingSystem
{
    public async UniTask<bool> HasKey(string key)
    {
        await UniTask.Delay(0);
        return File.Exists($"{Application.persistentDataPath}/{key}.json");
    }

    public async UniTask<T> Load<T>(string key)
    {
        await UniTask.Delay(0);
        return JsonUtility.FromJson<T>(File.ReadAllText($"{Application.persistentDataPath}/{key}.json"));
    }

    public async UniTask Save<T>(string key, T data)
    {
        await UniTask.Delay(0);
        File.WriteAllText($"{Application.persistentDataPath}/{key}.json", JsonUtility.ToJson(data));
    }
}