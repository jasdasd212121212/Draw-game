using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class StartGameButtonView : MonoBehaviour
{
    [Inject] private GameStateMachineModel _model;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        _model.StateMachine.GetState<GameplayState>().entered += OnStart;
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
        _model.StateMachine.GetState<GameplayState>().entered -= OnStart;
    }

    private void OnClick()
    {
        _model.StartGame();
    }

    private void OnStart()
    {
        gameObject.SetActive(false);
    }
}