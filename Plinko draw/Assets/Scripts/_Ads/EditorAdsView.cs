using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EditorAdsView
{
    public void ShowEditorAds(MonoBehaviour self)
    {
#if UNITY_EDITOR
        GameObject adsEditorBanner = new GameObject();
        adsEditorBanner.AddComponent<RectTransform>();
        adsEditorBanner.AddComponent<Image>();
        adsEditorBanner.GetComponent<Image>().color = new Color(0, 35, 255, 0.5f);
        adsEditorBanner.AddComponent<SignatureMarcup_EditorAdsBanner>();

        adsEditorBanner.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform);
        adsEditorBanner.transform.position = Vector3.zero;
        adsEditorBanner.transform.localScale = new Vector3(100, 100);

        self.StartCoroutine(DeactivateEditorAdsPanel());
#endif
    }

    private IEnumerator DeactivateEditorAdsPanel()
    {
#if UNITY_EDITOR
        yield return new WaitForSecondsRealtime(3f);
        GameObject.Destroy(GameObject.FindObjectOfType<SignatureMarcup_EditorAdsBanner>().gameObject);
#endif

        yield return 0;
    }
}