using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerPrefsJsonSaver : ISavingSystem
{
    public async UniTask<bool> HasKey(string key)
    {
        await UniTask.SwitchToMainThread();
        await UniTask.Delay(0);
        return PlayerPrefs.HasKey(key);
    }

    public async UniTask<T> Load<T>(string key)
    {
        await UniTask.SwitchToMainThread();
        await UniTask.Delay(0);
        return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
    }

    public async UniTask Save<T>(string key, T data)
    {
        await UniTask.SwitchToMainThread();
        await UniTask.Delay(0);
        PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
    }
}