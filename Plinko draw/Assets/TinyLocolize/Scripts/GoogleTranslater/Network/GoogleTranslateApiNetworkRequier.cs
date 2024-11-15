using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

public class GoogleTranslateApiNetworkRequier
{
    private readonly GoogleQueryPreparer _queryPreparer;
    private const string URL = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";

    public GoogleTranslateApiNetworkRequier()
    {
        _queryPreparer = new GoogleQueryPreparer();
    }

    public async UniTask<string> RequireTranslate(string isoCodeFrom, string isoCodeTo, string target)
    {
        target = _queryPreparer.Prepare(target);

        UnityWebRequest request = UnityWebRequest.Get(string.Format(URL, isoCodeFrom, isoCodeTo, target));

        await request.SendWebRequest();
        await UniTask.WaitWhile(() => request.downloadHandler.isDone == false);

        return request.downloadHandler.text;
    }
}