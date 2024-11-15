using TMPro;
using UnityEngine;

[RequireComponent(typeof(LoadLevelButton))]
public class LevelButtonTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = (GetComponent<LoadLevelButton>().TargetLevel + 1).ToString();
    }
}