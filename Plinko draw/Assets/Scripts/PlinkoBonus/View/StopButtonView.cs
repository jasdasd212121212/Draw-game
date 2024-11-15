using UnityEngine.UI;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Button))]
public class StopButtonView : MonoBehaviour
{
    [Inject] private PlinkoBonusStateMachine _stateMachine;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        _stateMachine.Abort();
    }
}