using Cysharp.Threading.Tasks;
using UnityEngine;

public class YandexEnvironmentDataWriteStrategy : IEnvironmentDataWriteStrategy
{
    public async UniTask WriteToData(EnvironmentData data)
    {
        WebLanguageCollector collector = GameObject.FindObjectOfType<WebLanguageCollector>();

        await UniTask.WaitWhile(() => collector.IsoCode == "");

        string isoCode = GameObject.FindObjectOfType<WebLanguageCollector>().IsoCode;

        Debug.Log($"Loaded ISO code - LANGUAGE: {isoCode}");
        data.WriteSegemnt(new LanguageDataSegment(isoCode));
    }
}