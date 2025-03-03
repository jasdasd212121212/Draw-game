using Cysharp.Threading.Tasks;
using UnityEngine;

public class WebLanguageCollector : MonoBehaviour
{
    [SerializeField][Min(0.01f)] private float _tryInitializeInterval = 1;

    public string IsoCode { get; private set; } = "";

    private void Awake()
    {
        TryIntervalInitialize().Forget();
    }

    private async UniTask TryIntervalInitialize()
    {
#if UNITY_EDITOR
        Debug.Log("Editor -> mock language");
        return;
#endif

        while (IsoCode == "")
        {
            Application.ExternalCall("CallLanguage");
            await UniTask.WaitForSeconds(_tryInitializeInterval);
        }
    }

    public void SetLanguage(string iso)
    {
        IsoCode = iso;
    }
}