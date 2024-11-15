using UnityEngine;
using System.IO;
using Cysharp.Threading.Tasks;

public class LocalFileStreamingAssetsLoader : ILocalLoader
{
    private readonly string PATH = $"{Application.streamingAssetsPath}/{LocalFileLoaderConfigSettings.LOCAL_FILE_NAME}.{LocalFileLoaderConfigSettings.LOCAL_FILE_EXTENSION}";

    public async UniTask<string> LoadLocal()
    {
        await UniTask.Delay(0);
        return File.ReadAllText(PATH);
    }

    public string LoadLocalSync()
    {
        return File.ReadAllText(PATH);
    }

    public async UniTask WriteLocal(string text)
    {
        await UniTask.Delay(0);
        File.WriteAllText(PATH, text);
    }

    public void WriteLocalSync(string text)
    {
        File.WriteAllText(PATH, text);
    }
}