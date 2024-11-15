using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public abstract class LevelButtonBase : MonoBehaviour
{
    [Inject] private LevelsLoaderPresenter _presenter;
    [Inject] private LevelsLoader _model;

    protected Button SelfButton { get; private set; }

    protected LevelsLoaderPresenter Presenter => _presenter;
    protected LevelsLoader Model => _model;

    private void Awake()
    {
        SelfButton = GetComponent<Button>();

        SelfButton.onClick.AddListener(OnClick);   
    }

    private void OnDestroy()
    {
        SelfButton.onClick.RemoveAllListeners();   
    }

    private void OnClick()
    {
        OnClicked();
    }

    protected abstract void OnClicked();
}