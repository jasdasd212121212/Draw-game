using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WebGlLocalFileLoader : ILocalLoader
{
    private readonly string PATH = $"{Application.streamingAssetsPath}/{LocalFileLoaderConfigSettings.LOCAL_FILE_NAME}.{LocalFileLoaderConfigSettings.LOCAL_FILE_EXTENSION}";

    public async UniTask<string> LoadLocal()
    {
        Debug.Log($"Web: {PATH}");

        UnityWebRequest requst = UnityWebRequest.Get(PATH);
        
        await requst.SendWebRequest();

        return requst.downloadHandler.text;
    }

    public string LoadLocalSync()
    {
        throw new System.NotImplementedException();
    }

    public async UniTask WriteLocal(string text)
    {
        await UniTask.Delay(0);
        throw new System.NotImplementedException();
    }

    public void WriteLocalSync(string text)
    {
        throw new System.NotImplementedException();
    }
}